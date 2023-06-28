using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaPontuacao : MonoBehaviour
{
    private int pontos;
    private AudioSource audioPontuacao;
    [SerializeField]
    private Text pontuacaoTexto;

    void Awake(){
        audioPontuacao = GetComponent<AudioSource>();
    }
    public void AdcionarPontos(){
        pontos++;
        pontuacaoTexto.text = pontos.ToString();
        audioPontuacao.Play();
    }
}
