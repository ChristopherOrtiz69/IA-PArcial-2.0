using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform target; // El objetivo que el NPC buscará
    public GameObject objectPrefab; // El objeto que se generará
    public float spawnRadius = 10f; // Radio de área para generar objetos
    public float separationRadius = 2f; // Radio de separación entre objetos
    public int maxObjectsToSpawn = 100; // Máximo número de objetos a generar

    private Seek seekBehavior; // Comportamiento de búsqueda

    private void Start()
    {
        // Inicializa el comportamiento de búsqueda
        seekBehavior = GetComponent<Seek>();
        seekBehavior.Target = target.position;

        // Genera objetos en posiciones aleatorias dentro del radio de área
        int objectsToSpawn = Random.Range(0, maxObjectsToSpawn);
        for (int i = 0; i < objectsToSpawn; i++)
        {
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
            randomPosition += transform.position; // Centra alrededor del NPC
            Instantiate(objectPrefab, randomPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        seekBehavior.Target = target.position;
    }
}
