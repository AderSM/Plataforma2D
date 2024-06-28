using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackState : State
{
    private SlimeController main;

    [SerializeField]
    private float timeBetweenAttacks;

    [SerializeField]
    private float attackDamage;

    private float timer;

    private float distancia;

    public override void OnEnterState(Controller controller)
    {
        main = controller as SlimeController;

        //timer = timeBetweenAttacks; //Para que ataque nada más alcanzar al jugador.

        main.SlimeVisual.color = Color.red; //Para ver visualmente cuando cambia de un estado a otro.
    }
    public override void OnUpdateState()
    {
        /*timer += Time.deltaTime;
        
        if (timer >= timeBetweenAttacks)
        {
            //LaunchAttack();
            main.Anim.SetBool("atacando", true);            //Empeiza a reproducir animacion y atacar
            timer = 0;
        }*/
        
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks)
        {
            main.Anim.SetBool("atacando", true);
            timer = 0;
        }

        distancia = Vector3.Distance(transform.position, main.SlimeTarget.position);
        if (distancia > main.AttackRange)
        {
            main.ChangeState(main.ChaseState);
        }
    }

    private void LaunchAttack()
    {
        if (main.SlimeTarget == null || distancia > main.AttackRange)
        {
            main.Anim.SetBool("atacando", false);
            return;
        }
        SistemaVidasPlayer sistemaVidas = main.SlimeTarget.GetComponentInParent<SistemaVidasPlayer>();
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
