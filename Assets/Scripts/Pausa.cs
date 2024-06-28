using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject canvas1;
    [SerializeField] private GameObject canvas2;
    [SerializeField] private AudioSource soundPlayer;
    [SerializeField] private Animator transitionAnim;

    [SerializeField]
    private TextMeshProUGUI textoTime;

    private int numTimer = 999;

    private void Start()
    {
        StartCoroutine(TimerGame());
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            canvas1.SetActive(true);
        }
    }

    public void ClickBotonReanudar()
    {
        canvas1.SetActive(false);
        soundPlayer.Play();
        Time.timeScale = 1;
    }

    public void ClickBotonOpciones()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        soundPlayer.Play();
    }
    public void ClickBotonRegresar()
    {
        canvas2.SetActive(false);
        canvas1.SetActive(true);
        soundPlayer.Play();
    }
    public void ClickBotonMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        soundPlayer.Play();
    }
    public void ClickBotonReiniciarNivel()
    {
        Time.timeScale = 1;
        StartCoroutine(ChangeToScene0());
        soundPlayer.Play();
    }
    IEnumerator ChangeToScene0()
    {
        transitionAnim.SetTrigger("exit");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    IEnumerator TimerGame()
    {
        while (numTimer > 0)
        {
            textoTime.text = numTimer.ToString();
            yield return new WaitForSeconds(1f);
            numTimer--;
        }
        // Si quieres que el texto desaparezca cuando llegue a 0
        textoTime.text = "0";
    }
}