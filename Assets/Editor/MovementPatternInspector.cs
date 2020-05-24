using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovementPattern))]
public class MovementPatternInspector : BezierSplineInspector
{
	private MovementPattern m_Pattern;

	GameObject obj;

	protected override BezierSpline GetSpline()
	{
		m_Pattern = target as MovementPattern;
		return m_Pattern.m_BezierSpline;
	}
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		base.OnInspectorGUI();
	}

	protected override void OnSceneGUI()
	{
		base.OnSceneGUI();
	}
}
