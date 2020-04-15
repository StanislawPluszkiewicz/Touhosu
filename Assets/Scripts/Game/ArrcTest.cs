using Components;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Unity.Rendering;
using Unity.Transforms;

public class ArrcTest : MonoBehaviour
{
    [SerializeField] Mesh mesh;
    [SerializeField] Material material;

    // Start is called before the first frame update
    void Start()
    {
        EntityManager eM = World.DefaultGameObjectInjectionWorld.EntityManager;

        Entity e = eM.CreateEntity(typeof(InputMovementComponent), typeof(RenderMesh), typeof(LocalToWorld), typeof(Translation), typeof(RenderBounds));

        eM.SetComponentData(e, new InputMovementComponent { m_Speed = 5 });
        eM.SetSharedComponentData(e, new RenderMesh { mesh = mesh, material = material });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
