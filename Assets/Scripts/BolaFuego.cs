using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private float impulsoDisparo;

    [SerializeField]
    private float attackDamage;

    [SerializeField]
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * impulsoDisparo, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            SistemaVidasPlayer sistemaVidas = elOtro.gameObject.GetComponent<SistemaVidasPlayer>();
            sistemaVidas.RecibirDanho(attackDamage);
            Destroy(this.gameObject);
        }
    }
}
