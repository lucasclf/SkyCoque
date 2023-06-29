using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    private Text pontuacaoTexto;
    private ControlaPontuacao controlaPontuacao;
    [SerializeField]
    private GameObject interfaceGameOver;
    private Text textoGameOver;

    void Awake(){
        controlaPontuacao = GameObject.FindAnyObjectByType<ControlaPontuacao>();
        pontuacaoTexto = GetComponentInChildren<Text>();
        textoGameOver = interfaceGameOver.transform.GetChild(1).GetComponentInChildren<Text>();
    }

    public void AlteraPlacar()
    {
        pontuacaoTexto.text = controlaPontuacao.GetPontos().ToString();
    }
    string GerarTexto(){
        int pontos = controlaPontuacao.GetPontos();
        int record = PlayerPrefs.GetInt("record");
        return string.Format("PONTUAÇÃO: {0}\n RECORDE: {1}.", pontos, record);
    }

    public void AtivaInterfaceGameOver(){
        AtivaPlacar();
        AlteraEstadoGameOver(true);
    }
    void AtivaPlacar(){
        controlaPontuacao.SalvarPontuacao();
        textoGameOver.text = GerarTexto();
    }

    public void AlteraEstadoGameOver(bool estado){
        interfaceGameOver.SetActive(estado);
    }
}
