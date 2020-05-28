using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierSpline)), CanEditMultipleObjects]
public class BezierSplineInspector : Editor {

	private const int stepsPerCurve = 10;
	private const float directionScale = 0.5f;
	private const float handleSize = 0.04f;
	private const float pickSize = 0.06f;

	private static Color[] modeColors = {
		Color.white,
		Color.yellow,
		Color.cyan
	};

	private BezierSpline spline;
	private Transform handleTransform;
	private Quaternion handleRotation;
	private int selectedIndex = -1;

	protected virtual BezierSpline GetSpline()
	{
		return target as BezierSpline;
	}

	public override void OnInspectorGUI () {
		spline = GetSpline();
		DrawDefaultInspector();
		if (spline != null)
		{
			// EditorGUI.BeginChangeCheck();
			// bool loop = EditorGUILayout.Toggle("Loop", spline.Loop);
			// if (EditorGUI.EndChangeCheck())
			// {
			// 	Undo.RecordObject(spline, "Toggle Loop");
			// 	EditorUtility.SetDirty(spline);
			// 	spline.Loop = loop;
			// }
			// for (int i = 0; i < spline.ControlPointCount; ++i)
			// {
			// 	DrawSelectedPointInspector(i);
			// }

			// if (selectedIndex >= 0 && selectedIndex < spline.ControlPointCount)
			// {
			// 	DrawSelectedPointInspector(selectedIndex);
			// }
			if (GUILayout.Button("Add Curve"))
			{
				Undo.RecordObject(spline, "Add Curve");
				spline.AddCurve();
				EditorUtility.SetDirty(spline);
			}
		}
	}

	private void DrawSelectedPointInspector(int i)
	{
		if (spline != null)
		{
			GUILayout.Label("Point " + i);
			EditorGUI.BeginChangeCheck();
			Vector3 point = EditorGUILayout.Vector3Field("Position", spline.GetControlPoint(i));
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(spline, "Move Point");
				EditorUtility.SetDirty(spline);
				spline.SetControlPoint(i, point);
			}
			EditorGUI.BeginChangeCheck();
			BezierControlPointMode mode = (BezierControlPointMode)EditorGUILayout.EnumPopup("Mode", spline.GetControlPointMode(i));
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(spline, "Change Point Mode");
				spline.SetControlPointMode(i, mode);
				EditorUtility.SetDirty(spline);
			}
		}
	}

	protected virtual void OnSceneGUI () {
		spline = GetSpline();
		if (spline != null)
		{
			handleTransform = spline.transform;
			handleRotation = Tools.pivotRotation == PivotRotation.Local ?
				handleTransform.rotation : Quaternion.identity;

			Vector3 p0 = ShowPoint(0);
			for (int i = 1; i < spline.ControlPointCount; i += 3)
			{
				Vector3 p1 = ShowPoint(i);
				Vector3 p2 = ShowPoint(i + 1);
				Vector3 p3 = ShowPoint(i + 2);

				Handles.color = Color.gray;
				Handles.DrawLine(p0, p1);
				Handles.DrawLine(p2, p3);

				Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);
				p0 = p3;
			}
			ShowDirections();
		}
	}

	public void ShowDirections ()
	{
		if (spline != null)
		{
			Handles.color = Color.green;
			Vector3 point = spline.GetPoint(0f);
			Handles.DrawLine(point, point + spline.GetDirection(0f) * directionScale);
			int steps = stepsPerCurve * spline.CurveCount;
			for (int i = 1; i <= steps; i++)
			{
				point = spline.GetPoint(i / (float)steps);
				Handles.DrawLine(point, point + spline.GetDirection(i / (float)steps) * directionScale);
			}
		}
	}
	public Vector3 ShowPoint (int index)
	{
		if (spline != null)
		{
			Vector3 point = handleTransform.TransformPoint(spline.GetControlPoint(index));
			float size = HandleUtility.GetHandleSize(point);
			if (index == 0)
			{
				size *= 2f;
			}
			Handles.color = modeColors[(int)spline.GetControlPointMode(index)];
			if (Handles.Button(point, handleRotation, size * handleSize, size * pickSize, Handles.DotCap))
			{
				selectedIndex = index;
				Repaint();
			}
			if (selectedIndex == index)
			{
				EditorGUI.BeginChangeCheck();
				point = Handles.DoPositionHandle(point, handleRotation);
				if (EditorGUI.EndChangeCheck())
				{
					Undo.RecordObject(spline, "Move Point");
					EditorUtility.SetDirty(spline);
					spline.SetControlPoint(index, handleTransform.InverseTransformPoint(point));
				}
			}
			return point;
		}
		return Vector3.zero;
	}
}