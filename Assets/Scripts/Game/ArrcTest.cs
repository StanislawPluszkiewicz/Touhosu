using Components;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ArrcTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EntityManager eM = World.DefaultGameObjectInjectionWorld.EntityManager;
        Entity e = eM.CreateEntity(typeof(InputMovementComponent));

        eM.SetComponentData(e, new InputMovementComponent { m_Vertical = 0, m_Horizontal = 0 }); ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
