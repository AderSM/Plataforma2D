using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttackState : State
{
    private BatController main;

    [SerializeField]
    private float timeBetweenAttacks;

    [SerializeField]
    private float attackDamage;

    private float timer;

    public override void OnEnterState(Controller controller)
    {
        main = controller as BatController;

        timer = timeBetweenAttacks; //Para que ataque nada más alcanzar al jugador.

        main.BatVisual.color = Color.red; //Para ver visualmente cuando cambia de un estado a otro.
    }
    public override void OnUpdateState()
    {
        timer += Time.deltaTime;
        if(timer >= timeBetweenAttacks)
        {
            //LaunchAttack();
            main.Anim.SetTrigger("atacar");
            timer = 0;
        }
        if (Vector3.Distance(transform.position, main.BatTarget.position) > main.AttackRange)
        {
            main.ChangeState(main.ChaseState);
        }
    }

    private void LaunchAttack()
    {
        if (main.BatTarget == null)
        {
            return;
        }
        SistemaVidasPlayer sistemaVidas = main.BatTarget.GetComponentInParent<SistemaVidasPlayer>();
        sistemaVidas.RecibirDanho(attackDamage);
    }

    public override void OnExitState()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            SistemaVidasPlayer sistemaVidas = elOtro.gameObject.GetComponent<SistemaVidasPlayer>();
            sistemaVidas.RecibirDanho(attackDamage);
        }
    }
}
