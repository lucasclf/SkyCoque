using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaIA : MonoBehaviour
{
    private ControlaJogador jogador;
    [SerializeField]
    private float tempoDeImpulso;
    // Start is called before the first frame update
    void Start()
    {
        jogador = GetComponent<ControlaJogador>();
        StartCoroutine(Impulsionar());
    }

    private IEnumerator Impulsionar(){
        while(true){
            yield return new WaitForSeconds(tempoDeImpulso);
            jogador.DarImpulso();

        }
    }
}
