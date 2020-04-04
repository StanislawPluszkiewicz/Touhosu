
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ScaleOverTimeComponent : IComponentData {

    public ScaleOverTimeComponent() {
    }

    public float3 m_NewScale;

    public float m_StartTime;

    public float m_Time;

    public AnimationCurve m_SpeedOverTime;

}