using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Components{
    public class HealthComponent : IComponentData {

        public HealthComponent() {
        }

        public float m_Amount;

        public delegate m_OnDeath;

    }
}