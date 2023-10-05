using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : Steering
{
    private int T;
    public GameObject pursuitTarget;
    private PlayerController _pController;

    public override Vector3 GetForce()
    {
        Vector3 desiredVelocity = Seek();
        // Calcula y devuelve la fuerza resultante
        return desiredVelocity;
    }

    private Vector3 Seek()
    {
        if (pursuitTarget == null)
        {
            return Vector3.zero;

        }


        Vector3 targetPosition = pursuitTarget.transform.position;
        Vector3 currentPosition = transform.position;
        Vector3 desiredDirection = (targetPosition - currentPosition).normalized;
        Vector3 desiredVelocity = desiredDirection * speed;

        return desiredVelocity;
    }
}
