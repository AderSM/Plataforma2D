using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaVidasEnemigos : MonoBehaviour
{
    [SerializeField]
    private float vidas;

    [SerializeField]
    private TextMeshProUGUI textoScore;

    [SerializeField]
    private AudioSource soundBum;

    private Animator anim;

    private static int numScore;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
        if ( vidas <= 0)
        {
            numScore++;
            textoScore.text = numScore.ToString();
            anim.SetTrigger("explosion");
        }
    }

    private void Muerte()
    {
        soundBum.Play();
        Destroy(this.gameObject);
    }
}
