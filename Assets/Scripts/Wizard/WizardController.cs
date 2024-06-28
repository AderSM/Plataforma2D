using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// En esta clase se definen los datos compartidos entre estados y los estados.
/// </summary>
public class WizardController : Controller
{

    [SerializeField]
    private float attackRange;  //Dato compartido por varios estados: Attack y Chase.

    [SerializeField]
    private SpriteRenderer wizardVisual;

    private Transform wizardTarget;  //Datos compartido por varios estados: Patrol y Chase.

    private Animator anim; //Dato compartido

    //Se definen los estados que va a tener el enemigo:
    private WizardPatrolState patrolState;
    private WizardChaseState chaseState;
    private WizardAttackState attackState;


    #region getters & setters
    public WizardPatrolState PatrolState { get => patrolState;}
    public WizardChaseState ChaseState { get => chaseState;}
    public WizardAttackState AttackState { get => attackState;}
    public Transform WizardTarget { get => wizardTarget; set => wizardTarget = value; }
    public float AttackRange { get => attackRange;}
    public SpriteRenderer WizardVisual { get => wizardVisual;}
    public Animator Anim { get => anim; set => anim = value; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InitStates();

        ChangeState(patrolState);

        anim = GetComponent<Animator>();
    }


    //Inicializa los estados pasando como parámetro el controlador al que pertenecen.
    private void InitStates()
    {
        patrolState = GetComponent<WizardPatrolState>();
        chaseState = GetComponent<WizardChaseState>();
        attackState = GetComponent<WizardAttackState>();
    }

    protected override void Update()
    {
        base.Update();
    }
}
