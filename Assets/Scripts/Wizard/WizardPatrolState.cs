using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardPatrolState : State
{
    private WizardController main;

    public override void OnEnterState(Controller controller)
    {
        
        main = controller as WizardController;

        main.WizardVisual.color = Color.blue; //Para ver visualmente cuando cambia de un estado a otro.
    }

    public override void OnUpdateState()
    {

    }

    private void PatrolBetweenPoints()
    {

    }

    public override void OnExitState()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DetectionPlayer"))
        {
            main.WizardTarget = collision.transform;
            main.ChangeState(main.ChaseState);
        }
    }
}
