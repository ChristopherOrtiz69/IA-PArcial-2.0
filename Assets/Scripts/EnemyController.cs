using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target; // El objetivo que el enemigo buscar�
    public Seek seek; // Comportamiento de b�squeda (debe estar adjunto al mismo GameObject)


    private void Start()
    {
        // Aseg�rate de que el Seek est� adjunto al mismo GameObject
        seek = GetComponent<Seek>();
        if (seek == null)
        {
            Debug.LogError("No se encontr� el componente Seek adjunto al GameObject del EnemyController.");
        }

    }

    private void Update()
    {
        // Asigna el objetivo al comportamiento de b�squeda (Seek)
        seek.Target = target.position;
    }

}
