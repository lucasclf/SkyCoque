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
    [SerializeField]
    private Image medalha;
    [SerializeField]
    private Sprite medalhaOuro;
    [SerializeField]
    private Sprite medalhaPrata;
    [SerializeField]
    private Sprite medalhaBronze;


    void Awake(){
        controlaPontuacao = GameObject.FindAnyObjectByType<ControlaPontuacao>();
        pontuacaoTexto = GetComponentInChildren<Text>();
        textoGameOver = interfaceGameOver.transform.GetChild(1).GetComponentInChildren<Text>();
    }

    public void AlteraPlacar()
    {
        pontuacaoTexto.text = controlaPontuacao.GetPontos().ToString();
    }
    string GerarTexto(int pontos, int record){
        return string.Format("PONTUAÇÃO: {0}\n RECORDE: {1}.", pontos, record);
    }

    public void AtivaInterfaceGameOver(){
        AtivaPlacar();
        AlteraEstadoGameOver(true);
    }
    void AtivaPlacar(){
        int pontos = controlaPontuacao.GetPontos();
        int record = PlayerPrefs.GetInt("record");
        controlaPontuacao.SalvarPontuacao();
        AtribuiCorMedalha(pontos, record);
        textoGameOver.text = GerarTexto(pontos, record);
    }

    public void AlteraEstadoGameOver(bool estado){
        interfaceGameOver.SetActive(estado);
    }

    void AtribuiCorMedalha(int pontos, int record){
        if(pontos >= record){
            medalha.sprite = medalhaOuro;
        } else if(pontos >= record/2){
            medalha.sprite = medalhaPrata;
        } else{
            medalha.sprite = medalhaBronze;
        }
    }
}
