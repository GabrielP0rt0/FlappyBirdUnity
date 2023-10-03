using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Pontuacao : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao;
    public int Pontos;
    private AudioSource audioPontuacao;

    public float TimeScale;
    public float PontuacaoInicial;
    public float CoeficienteDificuldade;
    private float pontuacaoAlcancar;
    private int desempenho = 0; 
    private void Awake()
    {
        this.audioPontuacao = GetComponent<AudioSource>();
        pontuacaoAlcancar = PontuacaoInicial;
        TimeScale = 1f;
    }
    private void Update()
    {
        if (desempenho > pontuacaoAlcancar)
        {
            desempenho = 0;
            pontuacaoAlcancar = (pontuacaoAlcancar * CoeficienteDificuldade + 100 * pontuacaoAlcancar) / 100;
            TimeScale += (CoeficienteDificuldade * TimeScale) / 100;
            Time.timeScale = TimeScale;
        }   
    }
    public void Pontuar(int pontos)
    {
        Pontos = pontos;
        this.textoPontuacao.text = this.Pontos.ToString();
        if (pontos > 0)
        {
            this.audioPontuacao.Play();
            desempenho++;
            return;
        }
        TimeScale = 1f;
        pontuacaoAlcancar = PontuacaoInicial;
        desempenho = 0;
    }
    private void AtualizaDificuldade()
    {

    }
}
