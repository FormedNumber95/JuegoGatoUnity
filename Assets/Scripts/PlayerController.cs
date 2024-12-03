using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;         //El rigidbody del gato
    SpriteRenderer sr;      //El spriteRenderer del gato
    Animator anim;          //La animacion
    public float velocidad; //La velocidad del gato

    // Awake, que se llama antes del Start
    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
    }

    //Diferente del update, controla mejor las actualizaciones
    void FixedUpdate()
    {
        //Establece la animacion
        bool isMoving = rb.velocity.magnitude == 0f;
        anim.SetBool("IsMoving", isMoving);
        //Si (pulsado click izquierdo)
        if(Input.GetMouseButton(0)){
            //Si (esta en la parte izquierda de la pantalla)
            if(Input.mousePosition.x<Screen.width/2){
                //Dar la velocidad
                rb.velocity=Vector2.left*velocidad;
                //invertir la x segun el spriteRenderer
                sr.flipX=true;
            }else{ //Si (esta en la parte derecha de la pantalla)
                //Dar la velocidad
                rb.velocity=Vector2.right*velocidad;
                //invertir la x segun el spriteRenderer
                sr.flipX=false;
            }
        }
    }
}
