using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public Transform target; // El objetivo que el jugador buscará
    public Transform enemy;  // El enemigo del que el jugador huirá

    //private Seek seekBehavior; // Comportamiento de búsqueda
    private RunAway runAwayBehavior; // Comportamiento de huida

    private void Start()
    {
        // Inicializa los comportamientos
        //seekBehavior = GetComponent<Seek>();
       // runAwayBehavior = GetComponent<RunAway>();

        // Asigna los objetivos iniciales
        //seekBehavior.Target = target.position;
       // runAwayBehavior.Target = enemy.position;
    }

    private void Update()
    {
        // Actualiza los objetivos de búsqueda y huida si es necesario
        //seekBehavior.Target = target.position;
       // runAwayBehavior.Target = enemy.position;

        // Aplica los comportamientos
        //Vector3 seekForce = seekBehavior.GetForce();
        //Vector3 runAwayForce = runAwayBehavior.GetForce();

        // Combina las fuerzas si es necesario (puedes ajustar esto según tus necesidades)
        //Vector3 totalForce = seekForce + runAwayForce;

        // Aplica la fuerza resultante al jugador (puedes ajustar esto según tus necesidades)
        Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce(totalForce);
    
    }
}
