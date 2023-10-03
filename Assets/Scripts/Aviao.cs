using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Aviao : MonoBehaviour
{
    public int Force;
    private Rigidbody2D aviao;
    private Vector3 position;
    private DiretorV2 diretor;
    private Obstaculo obstaculo;
    private void Awake()
    {
        this.position = transform.position;
        this.aviao = this.GetComponent<Rigidbody2D>();
    }
    private void Start()
        => this.diretor = GameObject.FindAnyObjectByType<DiretorV2>();
    private void Update()
    {
        bool impulsionar = (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space)) && this.diretor.Pausado == false;
        if (impulsionar)
            this.Impulsionar();
    }
    private void Impulsionar()
    {
        this.aviao.velocity = Vector2.zero;
        this.aviao.AddForce(Vector2.up * Force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.aviao.simulated = false;
        this.diretor.GameOver();
    }
    public void ResetFunction()
    {
        this.aviao.simulated = true;
        this.transform.position = this.position;
        this.aviao.velocity = Vector2.zero;
    }
}
