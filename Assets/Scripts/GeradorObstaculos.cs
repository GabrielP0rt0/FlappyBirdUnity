using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
    public float TempoParaGerar;
    private float cronometro;
    public GameObject ModeloObstaculo;

    private void Awake()
    {
        this.cronometro = this.TempoParaGerar;
    }
    // Update is called once per frame
    void Update()
    {
        this.cronometro -= Time.deltaTime;
        if (this.cronometro <= 0 )
        {
            this.cronometro = this.TempoParaGerar;
            GameObject.Instantiate(this.ModeloObstaculo, this.transform.position, Quaternion.identity) ;
        }
    }
}
