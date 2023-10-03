using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    public float Velocidade;
    private Vector3 posicaoInicial;
    private float tamanhoDaImagem;
    private float escalaX;
    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        this.tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x;
        this.escalaX = this.transform.localScale.x;
    }
    void Update()
    {
        float deslocamento = Mathf.Repeat(this.Velocidade * Time.time, this.tamanhoDaImagem * escalaX);
        this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
    }
}
