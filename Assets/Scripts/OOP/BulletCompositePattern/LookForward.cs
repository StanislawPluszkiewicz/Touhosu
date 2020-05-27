using Game;
using System.Collections;
using System.Collections.Generic;
using Unity.Transforms;
using UnityEngine;

public class LookForward : MonoBehaviour
{
    Actor actor;

    private void Start()
    {
        actor = GetComponentInParent<Actor>();
        if (actor == null)
            Debug.LogError("Au secours, actor = null", this);
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 movDirection = actor.MovementDirection;

        Quaternion q = Quaternion.AngleAxis(Vector3.Dot(actor.transform.right, movDirection), actor.transform.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, actor.AngularSpeed * Time.deltaTime);

    }
}
