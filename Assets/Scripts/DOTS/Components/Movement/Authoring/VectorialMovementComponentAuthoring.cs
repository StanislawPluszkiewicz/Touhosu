using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Game.Components;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class VectorialMovementComponentAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
	public float m_Speed;
	public float m_Acceleration;
	public float3 m_Direction;

	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		dstManager.AddComponentData(entity, new VectorialMovementComponent
		{
			m_Speed = m_Speed,
			m_Acceleration = m_Acceleration,
			m_Direction = m_Direction
		});
	}

	public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
	{
		// nothing to add
	}
}
