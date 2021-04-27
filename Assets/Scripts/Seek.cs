using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public GameObject targetGameObject = null;

    public Vector3 target = Vector3.zero;

    public Transform ballAttach;
    public Transform player;

    public void OnDrawGizmos()
    {
        if (isActiveAndEnabled && Application.isPlaying)
        {
            Gizmos.color = Color.cyan;
            if (targetGameObject != null)
            {
                target = targetGameObject.transform.position;
            }
            Gizmos.DrawLine(transform.position, target);
        }
    }

    public override Vector3 Calculate()
    {
        return boid.SeekForce(target);
    }

    public void Update()
    {
        if (targetGameObject != null)
        {
            target = targetGameObject.transform.position;
        }

        if (targetGameObject != null && Vector3.Distance(transform.position, targetGameObject.transform.position) < 3 && targetGameObject.tag == "Ball")
        {
            targetGameObject.transform.position = ballAttach.position;
            targetGameObject.transform.SetParent(ballAttach);
            targetGameObject.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<FPSController>().gotBall = true;
        }
    }
}