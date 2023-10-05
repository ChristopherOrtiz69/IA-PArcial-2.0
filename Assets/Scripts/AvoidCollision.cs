using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidCollision : Steering
{
    public ObstacleController obController; // Controlador de obstáculos
    public float maxSeeAhead;
    public float obstacleRadius;
    public float maxAvoidForce;
    public bool showVectors;

    private List<Vector3> _obstacleList = new List<Vector3>();
    private Vector3 _ahead, _ahead2;

    private void Start()
    {
        // Inicializa el controlador de obstáculos
        obController = GetComponent<ObstacleController>();
    }

    public override Vector3 GetForce()
    {
        // Calcula el vector de dirección hacia el objetivo
        Vector3 desiredDirection = (Target - Position).normalized;
        Vector3 desiredVelocity = desiredDirection * speed;

        // Calcula el vector de dirección anticipada
        _ahead = Position + (Velocity.normalized * maxSeeAhead);
        _ahead2 = Position + (Velocity.normalized * (maxSeeAhead * 0.5f));

        // Encuentra el obstáculo más grande en el camino
        Vector3? threat = FindBiggestThreat();

        if (threat != null)
        {
            // Calcula la fuerza de evasión
            Vector3 avoidForce = (Vector3)threat - Position;
            avoidForce = avoidForce.normalized * maxAvoidForce;

            // Combina la fuerza de evasión con la dirección deseada
            desiredVelocity += avoidForce;
        }

        return desiredVelocity;
    }

    private Vector3? FindBiggestThreat()
    {
        float closestObstacleDist = float.MaxValue;
        Vector3? closestObstacle = null;

        foreach (Vector3 obstacle in _obstacleList)
        {
            float dist = Vector3.Distance(Position, obstacle);

            if (dist < closestObstacleDist && CollisionDetected(Position, _ahead, obstacle))
            {
                closestObstacleDist = dist;
                closestObstacle = obstacle;
            }
        }

        return closestObstacle;
    }

    private bool CollisionDetected(Vector3 pos, Vector3 ahead, Vector3 obstacle)
    {
        float obstacleRadiusSq = obstacleRadius * obstacleRadius;
        float distanceSq = Vector3.SqrMagnitude(obstacle - pos);

        if (distanceSq < obstacleRadiusSq)
        {
            // El centro del obstáculo está dentro del radio de colisión
            return true;
        }

        // Comprueba si la línea de anticipación interseca el círculo del obstáculo
        Vector3 toObstacle = obstacle - ahead;
        float dot = Vector3.Dot(toObstacle, Velocity.normalized);

        if (dot < 0)
        {
            // El obstáculo está detrás de nosotros, no hay colisión anticipada
            return false;
        }

        Vector3 closestPoint = ahead + (Velocity.normalized * dot);
        float distanceToClosestSq = Vector3.SqrMagnitude(obstacle - closestPoint);

        return distanceToClosestSq < obstacleRadiusSq;
    }

    private void DrawVectors(Vector3 force)
    {
        if (showVectors)
        {
            // Dibuja los vectores de debug
            Debug.DrawRay(transform.position, Velocity.normalized * maxSeeAhead, Color.blue);
            Debug.DrawRay(transform.position, _ahead - transform.position, Color.red);
            Debug.DrawRay(transform.position, _ahead2 - transform.position, Color.green);
            Debug.DrawRay(transform.position, force, Color.cyan);
        }
    }
}
