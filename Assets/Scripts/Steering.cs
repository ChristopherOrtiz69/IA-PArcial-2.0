using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    // Variables públicas accesibles desde el editor
    public float speed;
    public Vector3 DesiredVelocity;
    public Vector3 Velocity;
    public Vector3 Position;
    public Vector3 Target;

    // Método abstracto para calcular la fuerza
    public abstract Vector3 GetForce();
}
