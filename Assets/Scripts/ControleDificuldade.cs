using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDificuldade : MonoBehaviour
{
    private float tempoDeJogo;
    [SerializeField]
    private float tempoDificuldadeMaxima;
    private float dificuldade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempoDeJogo += Time.deltaTime;
        Debug.Log(dificuldade);
        dificuldade = tempoDeJogo/tempoDificuldadeMaxima;
        dificuldade = Mathf.Min(1, dificuldade);
    }

    public float GetDificuldade(){
        return dificuldade;
    }
}
