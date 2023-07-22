using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class ControlaJogo : MonoBehaviour
{
    private ControlaCenario[] cenarios;
    private ControlaGeradorObstaculos geradorObstaculo;

    private ControlaJogador jogador;
    // Start is called before the first frame update
    void Start()
    {
        cenarios = GetComponentsInChildren<ControlaCenario>();
        geradorObstaculo = GetComponentInChildren<ControlaGeradorObstaculos>();
        jogador = GetComponentInChildren<ControlaJogador>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desativar(){
        geradorObstaculo.Parar();
        foreach(var cenario in cenarios){
            cenario.enabled = false;
        }
    }
    
    public void Ativar(){
        geradorObstaculo.Recomecar();
        foreach(var cenario in cenarios){
            cenario.enabled = true;
        }
        jogador.Reiniciar();
    }
}
