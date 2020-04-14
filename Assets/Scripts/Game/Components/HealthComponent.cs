using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Components{
    public struct HealthComponent : IComponentData {


        public float m_Amount;

        //public delegate m_OnDeath;

    }
}