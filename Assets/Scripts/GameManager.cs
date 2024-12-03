using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;             //Instancia del GameMAnager para llamarlo desde otro script
    public bool gameOver=false;                     //Indica si es GameOver o no
    private int puntuacion=0;                       //La puntuacion del jugador
    public Text marcador;                           //Texto que muestra la putnuacion del jugador
    private GameObject panel;                       //El panel en el que estan los botones de "Restart" y "Menu"
    [SerializeField]
    private GeneradorDeSierras generadorDeSierras;  //El generador de las sierras

    // Awake, se le llama antes del Start
    void Awake()
    {
        Instance=this;
        panel=GameObject.Find("Panel");
        panel.SetActive(false);
    }

    //Cuando acaba el juego, termina la ejecucion del spawn de sierras
    public void GameOver(){
        gameOver=true;
        //Lanzar el metodo StopSpawning de GeneradorDeSierras
        GameObject.Find("GeneradorDeSierras").GetComponent<GeneradorDeSierras>().StopSpawning();
    }

    //Incrementa la puntuacion cada vez que una sierra toque el suelo y aumenta la velocidad cada 10 puntos
    public void IncrementarPuntuacion(){
        //Detecta si es GameOver
        if(!gameOver){
            puntuacion++;
            marcador.text=puntuacion.ToString();
            //Aumentar la velocidad cada 10 puntos
            if (puntuacion % 10 == 0)
            {
                generadorDeSierras.AumentarVelocidadSpawn();
            }
        }
    }

    //Activa o desactiva el menu de GameOver en funcion de si es gameover o no
    public void toggleMenu(){
        if(!gameOver){
            panel.SetActive(true);
        }else{
            panel.SetActive(false);
        }
    }
}
