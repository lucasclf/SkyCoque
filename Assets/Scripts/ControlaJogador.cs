using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    private Rigidbody2D rigidbodyJogador;
    private ControlaCena diretor;
    [SerializeField]
    private float forca = 5;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbodyJogador = GetComponent<Rigidbody2D>();
    }

    void Start(){
        diretor = GameObject.FindObjectOfType<ControlaCena>();
    }

    // Update is called once per frame
    void Update()
    {
        Impulsionar();
        
    }

    void Impulsionar(){
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).phase == TouchPhase.Began){
                rigidbodyJogador.velocity = Vector2.zero;
                rigidbodyJogador.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
            }
        }
        if(Input.GetButtonDown("Fire1")){
            rigidbodyJogador.velocity = Vector2.zero;
            rigidbodyJogador.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
        };
    }


    void OnCollisionEnter2D(Collision2D objetoColidido){
        rigidbodyJogador.simulated = false;
        diretor.FinalizaJogo();
    }
}
