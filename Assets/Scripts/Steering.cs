using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Steering : MonoBehaviour
{
    // Variables p�blicas accesibles desde el editor
    public float speed;
    public Vector3 DesiredVelocity;
    public Vector3 Velocity;
    public Vector3 Position;
    public Vector3 Target;

    // M�todo abstracto para calcular la fuerza
    public abstract Vector3 GetForce();
}
