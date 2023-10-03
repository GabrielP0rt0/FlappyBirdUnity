using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DiretorV2 : MonoBehaviour
{
    public GameObject GameOverImg;
    public GameObject PauseImg;
    public bool Pausado; //Temp
    private TrilhaSonoraV2 trilhaSonora;
    private Aviao aviao;
    private Pontuacao pontuacao;
    private Obstaculo[] lstObstaculos;
    private bool firstPlay = true;
    private bool gameOver = false;
    private void Start()
    {
        aviao = GameObject.FindAnyObjectByType<Aviao>();
        trilhaSonora = GameObject.FindAnyObjectByType<TrilhaSonoraV2>();
        pontuacao = GameObject.FindAnyObjectByType<Pontuacao>();
        GameOver();
    }
    private void Update()
    {
        bool basePause = Input.GetKeyDown(KeyCode.P) && !gameOver;
        if (basePause)
            BasePause(true);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        trilhaSonora.Stop();
        if (firstPlay)
            return;
        GameOverImg.SetActive(true);
        gameOver = true;
    }
    public void PlayGame()
    {
        trilhaSonora.Play();
        if (firstPlay)
        {
            BasePause(false);
            firstPlay = false;
            return;
        }
        Time.timeScale = 1f;
        aviao.ResetFunction();
        DestroyObstaculos();
        pontuacao.Pontuar(0);
        GameOverImg.SetActive(false);
        gameOver = false;
    }
    public void PlayControl()
    {
        if (firstPlay)
        {
            PlayGame();
            return;
        }
        BasePause(false);
    }
    private void BasePause(bool state)
    {
        Time.timeScale = state ? 0f : pontuacao.TimeScale;
        PauseImg.SetActive(state);
        Pausado = state;
        if (!state)
            trilhaSonora.UnPause();
        if (state)
            trilhaSonora.Pause();
    }
    private void DestroyObstaculos()
    {
        lstObstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in lstObstaculos)
            obstaculo.Destruir();
    }
}
