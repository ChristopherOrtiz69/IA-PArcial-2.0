using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform target; // El objetivo que el NPC buscar�
    public GameObject objectPrefab; // El objeto que se generar�
    public float spawnRadius = 10f; // Radio de �rea para generar objetos
    public float separationRadius = 2f; // Radio de separaci�n entre objetos
    public int maxObjectsToSpawn = 100; // M�ximo n�mero de objetos a generar

    private Seek seekBehavior; // Comportamiento de b�squeda

    private void Start()
    {
        // Inicializa el comportamiento de b�squeda
        seekBehavior = GetComponent<Seek>();
        seekBehavior.Target = target.position;

        // Genera objetos en posiciones aleatorias dentro del radio de �rea
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
