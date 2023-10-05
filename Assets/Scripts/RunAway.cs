using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : Steering
{ // Variables públicas accesibles desde el editor
    public float runAwayCircle;
    public float safeRadius;
    public Transform player;
    public float moveSpeed = 5f;
    public float fleeDistance = 10f;

    // Override del método abstracto GetForce
    public override Vector3 GetForce()
    {
        Vector3 directionToPlayer = transform.position - player.position;
        Vector3 desiredDirection = (Position - Target).normalized;
        Vector3 desiredVelocity = desiredDirection * speed;
        Vector3 fleeDirection = directionToPlayer.normalized;

        fleeDirection = new Vector3(fleeDirection.x, 0f, fleeDirection.z);
        transform.position += fleeDirection * moveSpeed * Time.deltaTime;
        

        float distanceToTarget = Vector3.Distance(Position, Target);

        
        if (distanceToTarget < runAwayCircle)
        {
            return desiredVelocity;
        }
        else if (distanceToTarget < safeRadius)
        {
            // Si estamos dentro del radio seguro, aplicamos el frenado
            return desiredVelocity * (safeRadius / distanceToTarget);
        }
        else
        {
            // Si estamos fuera del radio seguro, no se aplica ninguna fuerza
            return Vector3.zero;
        }
    }

}
