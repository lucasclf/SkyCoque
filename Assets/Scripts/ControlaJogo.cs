using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogo : MonoBehaviour
{
    private ControlaCenario[] cenarios;
    private ControlaGeradorObstaculos geradorObstaculo;
    // Start is called before the first frame update
    void Start()
    {
        cenarios = GetComponentsInChildren<ControlaCenario>();
        geradorObstaculo = GetComponent<ControlaGeradorObstaculos>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desativar(){
        foreach(var cenario in cenarios){
            cenario.enabled = false;
            geradorObstaculo.Parar();
        }
    }
}
