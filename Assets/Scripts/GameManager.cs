using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool gameOver=false;
    private int puntuacion=0;
    public Text marcador;
    private GameObject panel;
    [SerializeField]
    private GeneradorDeSierras generadorDeSierras;

    // Start is called before the first frame update
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

    //incrementa la puntuacion cada vez que una sierra toque el suelo
    public void IncrementarPuntuacion(){
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
