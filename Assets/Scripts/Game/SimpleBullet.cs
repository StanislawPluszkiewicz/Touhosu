
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// #Bullets
/// - Bullet simple:
/// </summary>
public class SimpleBullet : BulletComposite {

    /// <summary>
    /// #Bullets
    /// - Bullet simple:
    /// </summary>
    public SimpleBullet() {
    }

    public VectorMovementComponent m_VectorialMovementComponent;

    public Mesh m_Mesh;

    public ScaleOverTimeComponent m_ScaleOverTimeComponent;

}