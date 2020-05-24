using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Weapon))]
public class WeaponInspector : MovementPatternInspector
{
	private Weapon m_Weapon;

	protected override BezierSpline GetSpline()
	{
		m_Weapon = target as Weapon;
		if (m_Weapon && m_Weapon.m_ShootPattern)
			return m_Weapon.m_ShootPattern.m_BezierSpline;
		return null;
	}

	public override void OnInspectorGUI()
	{
		// DrawDefaultInspector();
		base.OnInspectorGUI();


	}

	protected override void OnSceneGUI()
	{
		base.OnSceneGUI();
	}
}
