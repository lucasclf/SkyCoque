using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaCena : MonoBehaviour
{
    [SerializeField]
    private ControlaInterface controlaInterface;
    private ControlaJogador jogador;
    [SerializeField]
    private AudioSource audioSourceDiretor;
    [SerializeField]
    private AudioClip gameOverSound;
    void Awake(){
        Time.timeScale = 0; 
        controlaInterface = GameObject.FindAnyObjectByType<ControlaInterface>();
    }

    void Start(){
        jogador = GameObject.FindAnyObjectByType<ControlaJogador>();
    }
    public void FinalizaJogo(){
        Time.timeScale = 0; 
        controlaInterface.AtivaInterfaceGameOver();
        AlterarSom(gameOverSound);
    }

    public void ReiniciarJogo(){
        controlaInterface.AlteraEstadoGameOver(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Fase_01");
    }

    void DestruirObstaculos(){
        ControlaObstaculo[] obstaculos = GameObject.FindObjectsOfType<ControlaObstaculo>();
        foreach(ControlaObstaculo obstaculo in obstaculos){
            obstaculo.DestroiObstaculo();
        }
    }

    void AlterarSom(AudioClip novoAudio){
        audioSourceDiretor.Pause();
        audioSourceDiretor.clip = novoAudio;
        audioSourceDiretor.Play();
    }
}
