using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.Components
{
	public enum EInterpolation
	{
		/*LINEAR, */
		BEZIER
	}

	[GenerateAuthoringComponent]
	public struct InterpolationComponent : IComponentData
	{
	}
}