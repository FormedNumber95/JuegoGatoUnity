using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidadDeRotacion;   //Velocidad a la que rota la sierra



    // Parecido al update, pero toma el tiempo de actualizacion dependiendo del dispositivo
    void FixedUpdate()
    {
        //Rotar las sierra
        transform.Rotate(0,0,velocidadDeRotacion);
    }

    //Detecta cuando entra en contacto con el suelo y con el jugador (Objeto con el trigger activado)
    void OnTriggerEnter2D(Collider2D collision){
        //Si toca el suelo
        if(collision.tag=="suelo"){
            //Suma un punto
            GameManager.Instance.IncrementarPuntuacion();
            //Destrulle el objeto si esta tocando el suelo
            Destroy(gameObject);
        }
        //Si toca al jugador
        if(collision.tag=="Player"){
            //Destrulle al jugador
            Destroy(collision.gameObject);
            //Visualiza el menu
            GameManager.Instance.toggleMenu();
            //LLama a GameOver
            GameManager.Instance.GameOver();
        }
    }
}
