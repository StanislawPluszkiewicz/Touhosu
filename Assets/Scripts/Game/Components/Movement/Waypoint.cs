using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;


namespace Game.Components
{
	[GenerateAuthoringComponent]
	public struct Waypoint : IComponentData
	{
		public EInterpolation m_InterpolationType;
		public float m_Acceleration;
		public float m_Speed;
		public bool m_LookForward;
		public float3 m_NextPoint;

		public Waypoint(EInterpolation type, float acceleration, float speed, bool lookForward, float3 nextPoint)
		{
			m_InterpolationType = type;
			m_Acceleration = acceleration;
			m_Speed = speed;
			m_LookForward = lookForward;
			m_NextPoint = nextPoint;
		}
	}

	public struct WayPointBuilder : IComponentData
	{
		public EInterpolation m_InterpolationType;
		float m_Acceleration;
		float m_Speed;
		bool m_LookForward;
		float3 m_NextPoint;


		void WithType(EInterpolation type)
		{
			m_InterpolationType = type;
		}
		void WithAcceleration(float acceleration)
		{
			m_Acceleration = acceleration;
		}
		void WithSpeed(float speed)
		{
			m_Speed = speed;
		}
		void LookingForward(bool isIt)
		{
			m_LookForward = isIt;
		}
		void WithNextPoint(float3 nextPoint)
		{
			m_NextPoint = nextPoint;
		}
		Waypoint Build()
		{
			return new Waypoint(
				m_InterpolationType,
				(m_Acceleration != null) ? m_Acceleration : 1,
				(m_Speed != null) ? m_Speed : 1,
				(m_LookForward != null) ? m_LookForward : true,
				m_NextPoint);
		}

	}
}