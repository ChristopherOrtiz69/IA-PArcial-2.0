using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public LayerMask obstacleLayer; // Capa de obst�culos en la escena
    public float obstacleDetectionRadius = 5f; // Radio de detecci�n de obst�culos

    private List<Vector3> _obstacleList = new List<Vector3>();

    private void Update()
    {
        // Limpia la lista de obst�culos
        _obstacleList.Clear();

        // Encuentra obst�culos dentro del radio de detecci�n
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, obstacleDetectionRadius, obstacleLayer);

        foreach (var hitCollider in hitColliders)
        {
            // Agrega las posiciones de los obst�culos a la lista
            _obstacleList.Add(hitCollider.transform.position);
        }
    }

    public List<Vector3> GetObstacles()
    {
        return _obstacleList;
    }
}
