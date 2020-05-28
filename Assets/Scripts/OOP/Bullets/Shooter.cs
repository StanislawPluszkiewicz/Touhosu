using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Game
{
	public class Shooter : SerializedMonoBehaviour
	{
		[Tooltip("Once you have setup the variables below press the button 'CreateSplines'")]

		[ReadOnly] public BezierSpline OnePrefabToRuleThemAll;
		[SerializeField] UInt32 m_Directions; //  number of directions in which we shoot
		[SerializeField] [Range(0, 360)] float m_AngleSpread;
		[SerializeField] Bullet m_Prefab;
		[SerializeField] float m_FireRate;
		[SerializeField] float m_SplineLength;
		float m_NextFireTime;

		[SerializeField] [ReadOnly] public 
			List<BezierSpline> m_Splines;

		public void Awake()
		{
			if (OnePrefabToRuleThemAll == null)
				Debug.LogError("OnePrefabToRuleThemAll est nul", this);
		}
		[Button]
		public void CleanSplines(bool useDestroyImmediate = true)
		{
			foreach (var s in m_Splines)
			{
				if (s)
				{
					if (useDestroyImmediate) DestroyImmediate(s.gameObject);
					else Destroy(s.gameObject);
				}
			}
			m_Splines.Clear();
			foreach (Transform child in transform)
			{
				if (useDestroyImmediate) DestroyImmediate(child.gameObject);
				else Destroy(child.gameObject);
			}
		}
		
		public void CreateSplines()
		{
			CreationMethod(Rotation1);
		}

		delegate Quaternion RotationMethod(int i, Transform t);
		Quaternion Rotation1(int i, Transform t)
		{
			return Quaternion.AngleAxis(i * m_AngleSpread, t.forward);
		}

		private void CreationMethod(RotationMethod fn)
		{
			int n = (int)m_Directions / 2;
			for (int i = -n; i <= n; ++i)
			{
				BezierSpline s = Instantiate(OnePrefabToRuleThemAll,
					transform.position, Quaternion.identity, transform) as BezierSpline;
				Quaternion rotation = fn(i, transform);

				Vector3 p0 = s.GetControlPoint(0);
				for (int iPoint = 1; iPoint < s.ControlPointCount; iPoint+=3)
				{
					Vector3 p1 = s.GetControlPoint(iPoint);
					Vector3 p2 = s.GetControlPoint(iPoint + 1);
					Vector3 p3 = s.GetControlPoint(iPoint + 2);

					s.SetControlPoint(iPoint, rotation * p1);
					s.SetControlPoint(iPoint + 1, Quaternion.Inverse(rotation) * p2);
					s.SetControlPoint(iPoint + 2, rotation * p3);

					p0 = p3;
				}
				m_Splines.Add(s);
			}
		}




		public void Shoot(Transform m_Target = null)
		{
			Debug.Log(CanShoot());
			if (CanShoot())
			{
				foreach (var s in m_Splines)
				{
					dynamic bullet = m_Prefab.Instantiate(transform.position, transform);

					if (bullet is HomingBullet)
						(bullet as HomingBullet).Init(transform.up, m_Target, s);
					else if (bullet is Bullet)
						(bullet as Bullet).Init(transform.up, s);
					StartCoroutine(bullet.Travel());
				}
				m_NextFireTime = Time.time + m_FireRate;
			}
		}


		private bool CanShoot()
		{
			return Time.time > m_NextFireTime;
		}

		private void OnDrawGizmosSelected()
		{
			foreach (var s in m_Splines)
			{
				if (s != null)
				{
					Vector3 p0 = s.GetPoint(0);
					for (int i = 1; i < s.ControlPointCount; i += 3)
					{
						Vector3 p1 = s.GetPoint(i);
						Vector3 p2 = s.GetPoint(i + 1);
						Vector3 p3 = s.GetPoint(i + 2);
						Gizmos.DrawLine(p0, p1);
						Gizmos.DrawLine(p1, p2);
						Gizmos.DrawLine(p2, p3);
						p0 = p3;
					}
				}
			}
		}

		private void OnValidate()
		{
			CleanSplines(true);
			CreateSplines();
		}
	}
}
