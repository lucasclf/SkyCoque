using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCarrossel : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 5f;
    private Vector3 posicaoInicial;
    private float tamanhoReal;
    
    void Awake(){
        float tamanhoChao = GetComponent<SpriteRenderer>().size.x;
        float escalaChao = transform.localScale.x;

        posicaoInicial = transform.position;
        tamanhoReal = tamanhoChao * escalaChao;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deslocamento = Mathf.Repeat(velocidade * Time.time, tamanhoReal);
        transform.position = posicaoInicial + Vector3.left * deslocamento;
    }


}
