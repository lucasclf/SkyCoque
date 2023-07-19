using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlaJogador : MonoBehaviour
{
    private Rigidbody2D rigidbodyJogador;
    [SerializeField]
    private float forca = 5;
    [SerializeField]
    private UnityEvent aoColidir; 
    [SerializeField]
    private UnityEvent aoPassarPeloObstaculo;
    private bool deveImpulsionar = false;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbodyJogador = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocidade Y", rigidbodyJogador.velocity.y);
    }

    void FixedUpdate(){
        if(deveImpulsionar){
            Impulsionar();
        }
    }

    public void DarImpulso(){
        deveImpulsionar = true;
    }
    void Impulsionar(){
        rigidbodyJogador.velocity = Vector2.zero;
        rigidbodyJogador.AddForce(Vector2.up * forca, ForceMode2D.Impulse);
        deveImpulsionar = false;
    }


    void OnCollisionEnter2D(Collision2D objetoColidido){
        rigidbodyJogador.simulated = false;
        aoColidir.Invoke();
    }

    void OnTriggerEnter2D(Collider2D gatilhoColidido) {
        this.aoPassarPeloObstaculo.Invoke();
    }
}
