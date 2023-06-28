using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaGeradorObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerar;
    private float cronometro;
    [SerializeField]
    private GameObject Obstaculo;
    
    void Awake(){
        cronometro = tempoParaGerar;
    }
    void Start(){
    
    }

    void Update(){   
        cronometro -= Time.deltaTime;
        if(cronometro <0){
            GerarObstaculos();
        }
    }

    void GerarObstaculos(){
        GameObject.Instantiate(Obstaculo, transform.position, Quaternion.identity);
        cronometro = tempoParaGerar;
    }
}
