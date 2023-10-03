using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TrilhaSonoraV2 : MonoBehaviour
{
    private AudioSource trilhaSonora;
    private void Awake()
        => this.trilhaSonora = GetComponent<AudioSource>();
    public void Play()
        => trilhaSonora.Play();
    public void Stop()
        => trilhaSonora.Stop();
    public void Pause()
        => trilhaSonora.Pause();
    public void UnPause()
        => trilhaSonora.UnPause();
    
}
