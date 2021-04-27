using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Arrive : SteeringBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public float slowingDistance = 15.0f;

    public GameObject targetGameObject = null;
    public GameObject ballAttach;
    public Transform player, dog, ball;

    public override Vector3 Calculate()
    {
        return boid.ArriveForce(targetPosition, slowingDistance);
    }

    public void Update()
    {
        if (targetGameObject != null)
        {
            targetPosition = targetGameObject.transform.position;
        }

        if (Vector3.Distance(transform.position, targetGameObject.transform.position) < 10)
        {
            ball = dog.GetComponent<Seek>().targetGameObject.transform;
            ball.GetComponent<Rigidbody>().isKinematic = false;
            ball.SetParent(null);
            player.GetComponent<FPSController>().gotBall = false;
            dog.GetComponent<Seek>().enabled = false;
            dog.GetComponent<Arrive>().enabled = false;
            dog.GetComponent<Boid>().velocity = Vector3.zero;

        }
    }
}