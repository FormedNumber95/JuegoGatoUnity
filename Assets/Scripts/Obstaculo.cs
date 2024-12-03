using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidadDeRotacion;   //Velocidad a la que rota la sierra



    // Update is called once per frame
    void FixedUpdate()
    {
        //Rotar las sierra
        transform.Rotate(0,0,velocidadDeRotacion);
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="suelo"){
            //Suma un punto
            GameManager.Instance.IncrementarPuntuacion();
            //Destrulle el objeto si esta tocando el suelo
            Destroy(gameObject);
        }
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
