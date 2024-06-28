using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttackState : State
{
    private WizardController main;

    [SerializeField]
    private GameObject bolaFuego;
    
    [SerializeField]
    private Transform puntoSpawn;
    
    [SerializeField]
    private float timeBetweenAttacks;
    
    [SerializeField] 
    private float attackDamage;

    public override void OnEnterState(Controller controller)
    {
        main = controller as WizardController;

        main.WizardVisual.color = Color.red; //Para ver visualmente cuando cambia de un estado a otro.

        StartCoroutine(RutinaAtaque());
    }
    public override void OnUpdateState()
    {
        EnfocarDestino();
        if (Vector3.Distance(transform.position, main.WizardTarget.position) > main.AttackRange)
        {
            main.ChangeState(main.ChaseState);
        }
    }

    private void LaunchAttack()
    {
        SistemaVidasPlayer sistemaVidas = main.WizardTarget.GetComponentInParent<SistemaVidasPlayer>();
        sistemaVidas.RecibirDanho(attackDamage);
    }

    public override void OnExitState()
    {
        StopAllCoroutines();
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            SistemaVidasPlayer sistemaVidas = elOtro.gameObject.GetComponent<SistemaVidasPlayer>();
            sistemaVidas.RecibirDanho(attackDamage);
        }
    }

    IEnumerator RutinaAtaque()
    {
        while (true)
        {
            main.Anim.SetTrigger("atacar");
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }

    private void LanzarBola()
    {
        Instantiate(bolaFuego, puntoSpawn.position, transform.rotation);
    }

    private void EnfocarDestino()
    {
        if (main.WizardTarget.position.x > transform.position.x)
        {
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
    }
}
