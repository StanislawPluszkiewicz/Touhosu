using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Game
{
	class Shooter : SerializedMonoBehaviour
	{
		[Tooltip("Once you have setup the variables below press the button 'CreateSplines'")]

		[ReadOnly] public BezierSpline OnePrefabToRuleThemAll;
		[SerializeField] UInt32 m_Directions; //  number of directions in which we shoot
		[SerializeField] [Range(0, 360)] float m_AngleSpread;
		[SerializeField] Bullet m_Prefab;
		[SerializeField] float m_FireRate;
		[SerializeField] float m_SplineLength;
		float m_NextFireTime;

		[SerializeField] [ReadOnly] List<BezierSpline> m_Splines;

		public void Awake()
		{
			if (OnePrefabToRuleThemAll == null)
				Debug.LogError("OnePrefabToRuleThemAll est nul", this);
		}
		[Button]
		public void CleanSplines()
		{
			foreach (var s in m_Splines)
			{
				if (s) DestroyImmediate(s.gameObject);
			}
			m_Splines.Clear();
		}

		[Button]
		public void CreateSplines()
		{
			CleanSplines();
			int n = (int)m_Directions / 2;
			for (int i = -n; i <= n; ++i)
			{
				Debug.Log(i);
				BezierSpline s = Instantiate(OnePrefabToRuleThemAll, 
					transform.position, Quaternion.identity, transform) as BezierSpline;
				Quaternion rotation = Quaternion.AngleAxis(i * m_AngleSpread, transform.forward);
				for (int iPoint = 0; iPoint < s.ControlPointCount; ++i)
				{
					Vector3 point = s.GetControlPoint(iPoint);
					point = rotation * point;
				}
				m_Splines.Add(s);
			}
		}



		public void Shoot(Transform m_Target = null)
		{
			if (CanShoot())
			{
				// dynamic bullet = m_BulletPrefab.Instantiate(GetFirePosition(), transform);
				// 
				// if (bullet is HomingBullet)
				// 	(bullet as HomingBullet).Init(transform.up, m_Target, m_ShootPattern);
				// else if (bullet is Bullet)
				// 	(bullet as Bullet).Init(transform.up, m_ShootPattern);
				// StartCoroutine(bullet.Travel());
				// 
				// m_NextFireTime = Time.time + m_FireRate;
			}
		}


		private bool CanShoot()
		{
			return Time.time > m_NextFireTime;
		}
	}
}
