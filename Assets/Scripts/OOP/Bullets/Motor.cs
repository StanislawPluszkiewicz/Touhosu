using System.Collections;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game
{
	public class Motor : MonoBehaviour
	{
		// [SerializeField] BezierCurve m_BezierCurve;
		[SerializeField] public BezierSpline m_BezierSpline;

		public void CreateDefaultBezierSpline()
		{
			UnityEngine.Object prefab = Resources.Load<BezierSpline>("bezier_spline_default");
			m_BezierSpline = Instantiate(prefab, transform.position, Quaternion.identity, transform) as BezierSpline;
		}

		public Vector3 GetVelocity(float t)
		{
			return m_BezierSpline.GetVelocity(t);
		}
		public float GetDecimalTime(float t)
		{
			return t - (float)Math.Truncate(t);
		}
		public Vector3 GetFinalVelocity(float t)
		{
			return GetVelocity(GetDecimalTime(t)) * Time.deltaTime;
		}
	}
}