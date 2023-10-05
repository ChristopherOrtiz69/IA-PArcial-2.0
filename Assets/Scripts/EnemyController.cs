using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target; // El objetivo que el enemigo buscará
    public Seek seek; // Comportamiento de búsqueda (debe estar adjunto al mismo GameObject)


    private void Start()
    {
        // Asegúrate de que el Seek esté adjunto al mismo GameObject
        seek = GetComponent<Seek>();
        if (seek == null)
        {
            Debug.LogError("No se encontró el componente Seek adjunto al GameObject del EnemyController.");
        }

    }

    private void Update()
    {
        // Asigna el objetivo al comportamiento de búsqueda (Seek)
        seek.Target = target.position;
    }

}
