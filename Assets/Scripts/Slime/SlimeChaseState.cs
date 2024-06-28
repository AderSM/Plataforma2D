using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeChaseState : State
{
    private SlimeController main;

    [SerializeField]
    private float chaseVelocity;


    public override void OnEnterState(Controller controller)
    {
        main = controller as SlimeController;

        main.SlimeVisual.color = Color.yellow; //Para ver visualmente cuando cambia de un estado a otro.
    }
    public override void OnUpdateState()
    {
        ChaseTarget();
    }

    private void ChaseTarget()
    {
        EnfocarDestino();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(main.SlimeTarget.position.x, transform.position.y, transform.position.z), chaseVelocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, main.SlimeTarget.position) < main.AttackRange)
        {
            main.ChangeState(main.AttackState);
        }
    }

    public override void OnExitState()
    {
        
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.TryGetComponent(out Player _))
        if (collision.gameObject.CompareTag("DetectionPlayer"))
        {
            main.ChangeState(main.PatrolState);
        }
    }*/

    private void EnfocarDestino()
    {
        if(main.SlimeTarget == null)
        {
            return;
        }
        if (main.SlimeTarget.position.x > transform.position.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
