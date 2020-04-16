
using Components;
using Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Entities;

public class LifespanSystem : ComponentSystem
{

    protected override void OnUpdate()
    {
        Entities.ForEach((Entity e, ref LifespanComponent lifespanComponent) =>
        {
            lifespanComponent.m_lifespan -= Time.DeltaTime;
            if(lifespanComponent.m_lifespan <= 0f)
            {
                PostUpdateCommands.DestroyEntity(e);
            }
        });
    }

}