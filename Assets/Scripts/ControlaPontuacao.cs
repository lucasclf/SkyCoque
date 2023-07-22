using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlaPontuacao : MonoBehaviour
{
    private int pontos;
    private AudioSource audioPontuacao;
    [SerializeField]
    private UnityEvent aoPontuar;
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
        aoPontuar.Invoke();
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
