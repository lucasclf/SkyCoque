using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaPontuacao : MonoBehaviour
{
    private int pontos;
    private AudioSource audioPontuacao;
    private int pontuacaoMaxima;
    private ControlaInterface controlaInterface;

    void Awake(){
        audioPontuacao = GetComponent<AudioSource>();
        controlaInterface = GameObject.FindAnyObjectByType<ControlaInterface>();
        pontuacaoMaxima = PlayerPrefs.GetInt("record");
    }
    public void AdcionarPontos(){
        pontos++;
        controlaInterface.AlteraPlacar();
        audioPontuacao.Play();
    }

    public void SalvarPontuacao(){
        if(pontos > pontuacaoMaxima){
            PlayerPrefs.SetInt("record", pontos);
        }
    }

    public int GetPontos(){
        return pontos;
    }
}
