using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas1;
    
    [SerializeField]
    private GameObject canvas2;

    [SerializeField]
    private TextMeshProUGUI textoScore;

    [SerializeField]
    private TextMeshProUGUI textoTime;

    [SerializeField]
    private TextMeshProUGUI textoScoreFinal;

    private int cantidadSumaScore;

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
            Time.timeScale = 0;
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            
            textoScoreFinal.text = SumaScore().ToString();
        }
    }

    private int SumaScore()
    {
        return cantidadSumaScore = int.Parse(textoScore.text) + (999 - int.Parse(textoTime.text));
    }
}
