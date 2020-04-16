using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Game;

namespace Game.Components
{
    [GenerateAuthoringComponent]
    public struct PathMovementComponent : IComponentData
	{
		public float3 m_StartPoint;


        
        //public Waypoint[] m_Waypoints;
    }
}