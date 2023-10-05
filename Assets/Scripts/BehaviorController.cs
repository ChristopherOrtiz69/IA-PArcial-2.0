using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    // Variables públicas accesibles desde el editor
    public List <Steering> behaviors;
    public float maxSpeed = 5f;
    public float maxForce = 5f;

    // Variables privadas
    private Vector3 _totalForce;
    private Vector3 _velocity;

    // Método que se llama en cada FixedUpdate
    private void FixedUpdate()
    {
        // Calcula la fuerza total resultante de los comportamientos
        _totalForce = Vector3.zero;
        foreach (Steering behavior in behaviors)
        {
            _totalForce += behavior.GetForce();
        }

        // Limita la fuerza total
        _totalForce = LimitVector(_totalForce, maxForce);

        // Aplica la fuerza al objeto
        _velocity += _totalForce * Time.fixedDeltaTime;
        _velocity = LimitVector(_velocity, maxSpeed);
        transform.position += _velocity * Time.fixedDeltaTime;
    }

    // Método para limitar un vector a una magnitud máxima
    private Vector3 LimitVector(Vector3 vector, float limit)
    {
        if (vector.magnitude > limit)
        {
            vector = vector.normalized * limit;
        }
        return vector;
    }
}
