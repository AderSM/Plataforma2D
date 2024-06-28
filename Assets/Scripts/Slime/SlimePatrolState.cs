using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePatrolState : State
{
    private SlimeController main;

    [SerializeField]
    //private Transform pointA, pointB;
    private Transform[] waypoints;

    [SerializeField]
    private float patrolVelocity;


    private Transform currentDestination;

    private int indiceActual;

    public override void OnEnterState(Controller controller)
    {
        
        main = controller as SlimeController;

        //currentDestination = pointA;
        currentDestination = waypoints[indiceActual].transform;

        main.SlimeVisual.color = Color.blue; //Para ver visualmente cuando cambia de un estado a otro.
    }

    public override void OnUpdateState()
    {
        PatrolBetweenPoints();
    }

    private void PatrolBetweenPoints()
    {
        //Nos vamos moviendo...
        EnfocarDestino();
        transform.position = Vector3.MoveTowards(transform.position, currentDestination.position, patrolVelocity * Time.deltaTime);
        if (transform.position == currentDestination.position) //Si llegamos al destino...
        {
            //Cambiamos. Si teníamos como destino A, pasamos a B y viceversa. (Operador ternario)
            //currentDestination = currentDestination == pointA ? pointB : pointA;
            DefinirNuevoDestino();
        }
    }

    public override void OnExitState()
    {
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.TryGetComponent(out Player player))
        if (collision.gameObject.CompareTag("DetectionPlayer"))
        {
            main.SlimeTarget = collision.transform;
            main.ChangeState(main.ChaseState);
        }
    }*/

    private void DefinirNuevoDestino()
    {
        indiceActual++;
        if (indiceActual >= waypoints.Length)
        {
            indiceActual = 0;
        }
        currentDestination = waypoints[indiceActual].transform;
        EnfocarDestino();
    }

    public void EnfocarDestino()
    {
        if (currentDestination.position.x > transform.position.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
