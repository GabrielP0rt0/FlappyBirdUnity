using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float VelocidadeObstaculo;
    public float RangeMinimo;
    public float RangeMaximo;
    private Vector3 posicaoAviao;
    private Pontuacao contador;
    private bool registrado = false;
    private int ponto;
    private void Awake()
        => this.transform.Translate(Vector3.up * Random.Range(RangeMinimo, RangeMaximo));
    private void Start()
    {
        this.posicaoAviao = GameObject.FindAnyObjectByType<Aviao>().transform.position;
        this.contador = GameObject.FindAnyObjectByType<Pontuacao>();
    }
    private void Update()
    {
        this.transform.Translate(Vector3.left * VelocidadeObstaculo * Time.deltaTime);
        bool pontuacao = (this.transform.position.x < this.posicaoAviao.x) && (!this.registrado);
        if (pontuacao)
        {
            this.contador.Pontos++;
            ponto = this.contador.Pontos;
            this.contador.Pontuar(ponto);
            this.registrado = true;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
        => Destruir();
    public void Destruir()
        => GameObject.Destroy(this.gameObject);
}
