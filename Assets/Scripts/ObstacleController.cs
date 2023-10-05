using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public LayerMask obstacleLayer; // Capa de obstáculos en la escena
    public float obstacleDetectionRadius = 5f; // Radio de detección de obstáculos

    private List<Vector3> _obstacleList = new List<Vector3>();

    private void Update()
    {
        // Limpia la lista de obstáculos
        _obstacleList.Clear();

        // Encuentra obstáculos dentro del radio de detección
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, obstacleDetectionRadius, obstacleLayer);

        foreach (var hitCollider in hitColliders)
        {
            // Agrega las posiciones de los obstáculos a la lista
            _obstacleList.Add(hitCollider.transform.position);
        }
    }

    public List<Vector3> GetObstacles()
    {
        return _obstacleList;
    }
}
