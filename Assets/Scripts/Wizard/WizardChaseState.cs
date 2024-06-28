using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardChaseState : State
{
    private WizardController main;

    public override void OnEnterState(Controller controller)
    {
        main = controller as WizardController;

        main.WizardVisual.color = Color.yellow; //Para ver visualmente cuando cambia de un estado a otro.
    }
    public override void OnUpdateState()
    {
        ChaseTarget();
    }

    private void ChaseTarget()
    {
        if (Vector3.Distance(transform.position, main.WizardTarget.position) < main.AttackRange)
        {
            main.ChangeState(main.AttackState);
        }
    }

    public override void OnExitState()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DetectionPlayer"))
        {
            main.ChangeState(main.PatrolState);
        }
    }
}
