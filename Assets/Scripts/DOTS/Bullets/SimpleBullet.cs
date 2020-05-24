
using Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

/// <summary>
/// #Bullets
/// - Bullet simple:
/// </summary>
[RequireComponent(typeof(VectorialMovementComponentAuthoring))]
[RequireComponent(typeof(ConvertToEntity))]
public class SimpleBullet : BulletComposite
{
	public GameObject m_GFX;
	public VectorialMovementComponentAuthoring m_VectorialMovementComponent;
	public LayerMask m_InteractWith;

	/// <summary>
	/// #Bullets
	/// - Bullet simple:
	/// </summary>
	public SimpleBullet()
	{

    }

	public void Awake()
	{
		m_VectorialMovementComponent = GetComponent<VectorialMovementComponentAuthoring>();
	}

}
[DisallowMultipleComponent]
[RequiresEntityConversion]
public class SimpleBulletAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
	public SimpleBullet m_Bullet;

	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		dstManager.AddComponentData(entity, new BulletComponent
		{
			m_GFX = m_Bullet.m_GFX,
			m_VectorialMovementComponent = m_Bullet.m_VectorialMovementComponent,
			m_InteractWith = m_Bullet.m_InteractWith
		});
	}

	public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
	{
		// nothing to add
	}
}