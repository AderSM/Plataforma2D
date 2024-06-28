using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaVidasPlayer : MonoBehaviour
{
    [SerializeField]
    private float vidas;

    [SerializeField]
    private TextMeshProUGUI textoVidas;

    [SerializeField]
    private GameObject canvas1;
    
    [SerializeField]
    private GameObject canvas2;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
        textoVidas.text ="" + vidas;
        if (vidas <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Time.timeScale = 0;
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        Destroy(this.gameObject);
    }
}
