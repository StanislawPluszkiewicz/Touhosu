using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;


namespace Game.Components
{
	class BulletComponent : IComponentData
	{
		public GameObject m_GFX;
		public VectorialMovementComponentAuthoring m_VectorialMovementComponent;
		public LayerMask m_InteractWith;
	}
}
