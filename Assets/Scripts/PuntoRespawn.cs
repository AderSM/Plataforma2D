using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoRespawn : MonoBehaviour
{
    [SerializeField]
    private Transform puntoRespawn;

    [SerializeField]
    private float attackDamage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            elOtro.gameObject.transform.position = puntoRespawn.position;
            SistemaVidasEnemigos sistemaVidas = elOtro.gameObject.GetComponent<SistemaVidasEnemigos>();
            sistemaVidas.RecibirDanho(attackDamage);
        }
    }
}