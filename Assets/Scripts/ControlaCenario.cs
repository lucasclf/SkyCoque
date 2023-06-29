using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCenario : MonoBehaviour
{
    [SerializeField]
    private VariaveisCompartilhadas velocidades;
    private GameObject[] chaos;
    private GameObject[] fundos;
    private Vector3[] posicaoInicialChao;
    private float[] tamanhoRealChao;
    private Vector3[] posicaoInicialFundo;
    private float[] tamanhoRealFundo;
    
    // Start is called before the first frame update
    void Start()
    {
        RecuperarObjetos();
    }

    // Update is called once per frame
    void Update()
    {
        MoverFundo();
        MoverChao();
    }

    void RecuperarObjetos(){
        chaos = GameObject.FindGameObjectsWithTag("chao");
        fundos = GameObject.FindGameObjectsWithTag("fundo");

        posicaoInicialChao = RecuperaPosicaoInicial(chaos);
        tamanhoRealChao = RecuperaTamanhoReal(chaos);
        
        posicaoInicialFundo = RecuperaPosicaoInicial(fundos);
        tamanhoRealFundo = RecuperaTamanhoReal(fundos);

    }

    Vector3[] RecuperaPosicaoInicial(GameObject[] objetos){
        int quantidadeObjetos = objetos.Length;
        Vector3[] posicoesInicial = new Vector3[quantidadeObjetos];
        int index = 0;
        foreach(GameObject objeto in objetos){
            Vector3 posicao = objeto.transform.position;
            posicoesInicial[index] = posicao;
            index++;
        }

        return posicoesInicial;
    }

    float[] RecuperaTamanhoReal(GameObject[] objetos){
        int quantidadeObjetos = objetos.Length;
        float[] tamanhosReais = new float[quantidadeObjetos];
        int index = 0;
        foreach(GameObject objeto in objetos){
            float posicao = objeto.GetComponent<SpriteRenderer>().size.x * chaos[0].transform.localScale.x;
            tamanhosReais[index] = posicao;
            index++;
        }

        return tamanhosReais;
    }
    
    void MoverFundo(){
        int index = 0;
        foreach(GameObject fundo in fundos){
            float deslocamento = Mathf.Repeat(velocidades.VelocidadeFundoFloat * Time.time, tamanhoRealFundo[index]);
            fundo.transform.position = posicaoInicialFundo[index] + Vector3.left * deslocamento;
            index++;
        }
    }

    void MoverChao(){
        int index = 0;
        foreach(GameObject chao in chaos){
            float deslocamento = Mathf.Repeat(velocidades.VelocidadeChaoFloat * Time.time, tamanhoRealChao[index]);
            chao.transform.position = posicaoInicialChao[index] + Vector3.left * deslocamento;
            index++;
        }
    }

    void MoverObstaculos(){

    }
}
