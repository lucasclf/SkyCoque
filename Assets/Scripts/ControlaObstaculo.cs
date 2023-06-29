using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaObstaculo : MonoBehaviour
{
    [SerializeField]
    private VariaveisCompartilhadas velocidades;
    [SerializeField]
    private float variacaoPosicaoY;
    private Vector3 posicaoJogador;
    private bool pontuei = false;
    private ControlaPontuacao pontuacao;
    void Awake(){
        
        transform.Translate(Vector3.up * Random.Range(-variacaoPosicaoY, variacaoPosicaoY));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        posicaoJogador = GameObject.FindAnyObjectByType<ControlaJogador>().transform.position;
        pontuacao = GameObject.FindAnyObjectByType<ControlaPontuacao>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * velocidades.VelocidadeObstaculoFloat * Time.deltaTime);
        if(!pontuei && transform.position.x < posicaoJogador.x){
            ContarPonto();
        }
    }

    void OnTriggerEnter2D(Collider2D objetoColidido){
        DestroiObstaculo();
    }

    public void DestroiObstaculo(){
        GameObject.Destroy(gameObject);
    }

    void ContarPonto(){
        pontuei = true;
        pontuacao.AdcionarPontos();
    }

}
