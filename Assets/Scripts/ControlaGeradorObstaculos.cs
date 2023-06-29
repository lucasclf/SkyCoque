using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaGeradorObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;
    [SerializeField]
    private float tempoParaGerarDificil;
    private float cronometro;
    [SerializeField]
    private GameObject Obstaculo;
    private ControleDificuldade controleDificuldade;
    
    void Awake(){
        cronometro = tempoParaGerarFacil;
    }
    void Start(){
        controleDificuldade = GameObject.FindAnyObjectByType<ControleDificuldade>();
    }

    void Update(){   
        cronometro -= Time.deltaTime;
        if(cronometro <0 ){
            GerarObstaculos();
        }
    }

    void GerarObstaculos(){
        GameObject.Instantiate(Obstaculo, transform.position, Quaternion.identity);
        cronometro = Mathf.Lerp(tempoParaGerarFacil, tempoParaGerarDificil, controleDificuldade.GetDificuldade());
    }
}
