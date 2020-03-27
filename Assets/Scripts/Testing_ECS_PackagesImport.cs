using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;

public class Testing_ECS_PackagesImport : MonoBehaviour
{

	[SerializeField] Mesh mesh;
	[SerializeField] Material material;


	private void Start()
	{
		EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;


		EntityArchetype entityArchetype = entityManager.CreateArchetype(
			typeof(LevelComponent),
			typeof(Translation),
			typeof(RenderMesh),
			typeof(LocalToWorld),
			typeof(RenderBounds),
			typeof(ChunkWorldRenderBounds),
			typeof(MoveSpeedComponent)
		);

		NativeArray<Entity> entityArray = new NativeArray<Entity>(10000, Allocator.Temp);
		entityManager.CreateEntity(entityArchetype, entityArray);


		for (int i = 0; i < entityArray.Length; ++i)
		{
			Entity entity = entityArray[i];
			entityManager.SetComponentData(entity, 
				new LevelComponent {
					level = UnityEngine.Random.Range(10, 20)
			});
			entityManager.SetComponentData(entity, 
				new MoveSpeedComponent {
					moveSpeed = UnityEngine.Random.Range(1f, 2f)
			});
			entityManager.SetComponentData(entity, 
				new Translation {
					Value = new float3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-8f, 8f), 0)
			});

			entityManager.SetSharedComponentData(entity, new RenderMesh {
				mesh = mesh,
				material = material
			});
		}

		entityArray.Dispose();

	}
}
