using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{
    private Rigidbody2D rigidbodyJogador;
    private ControlaCena diretor;
    [SerializeField]
    private float forca = 5;
    private bool deveImpulsionar = false;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbodyJogador = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start(){
        diretor = GameObject.FindObjectOfType<ControlaCena>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).phase == TouchPhase.Began){
                deveImpulsionar = true;
            }
        }
        if(Input.GetButtonDown("Fire1")){
            deveImpulsionar = true;
        };

        animator.SetFloat("Velocidade Y", rigidbodyJogador.velocity.y);
    }

    void FixedUpdate(){
        if(deveImpulsionar){
            Impulsionar();
        }
    }

    void Impulsionar(){
        rigidbodyJogador.velocity = Vector2.zero;
        rigidbodyJogador.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
        deveImpulsionar = false;
    }


    void OnCollisionEnter2D(Collision2D objetoColidido){
        rigidbodyJogador.simulated = false;
        diretor.FinalizaJogo();
    }
}
