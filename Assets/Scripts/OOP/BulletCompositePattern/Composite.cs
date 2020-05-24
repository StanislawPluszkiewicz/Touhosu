using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Composite : Component
{
	/* ===== Composite pattern implementation ===== */
	[Header("Composite")]
	public List<Component> m_Childs;
	public void Add(Component c)
	{
		m_Childs.Add(c);
	}
	public void Remove(Component c)
	{
		m_Childs.Remove(c);
	}
	public Component Get(int childIndex)
	{
		return m_Childs[childIndex];
	}

	/* ===== Composite pattern method ===== */
	public override void CompositeOperation()
	{

	}
}
