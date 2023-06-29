using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaMao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            if(Input.GetTouch(0).phase == TouchPhase.Began){
                Desaparecer();
            }
        }
        if(Input.GetButtonDown("Fire1")){
            Desaparecer();
        };
    }

    void Desaparecer(){
        Time.timeScale = 1;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
