using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Steering
{
    public Transform target;
    public bool arrival;
    public float slowingRadius;


    public override Vector3 GetForce()
    {

        Vector3 desiredDirection = target.position - transform.position;
        Vector3 desiredVelocity = desiredDirection.normalized * speed;
        Vector3 steeringForce = desiredVelocity - Velocity;
        transform.Translate(Velocity * Time.deltaTime);

        // Si se utiliza la llegada y estamos dentro del radio de frenado
        if (arrival && Vector3.Distance(Position, Target) < slowingRadius)
        {
            // Aplica frenado gradual
            steeringForce = steeringForce.normalized * (speed * (Vector3.Distance(Position, Target) / slowingRadius));
        }

        return steeringForce;
    }
}
