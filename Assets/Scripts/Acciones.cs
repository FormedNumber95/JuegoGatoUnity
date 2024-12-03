using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Acciones : MonoBehaviour
{
    //Salir de la app
    public void cerrar(){
        //print("Voy a salir");
        //Esto no funciona en el editor de Unity, pero si en ejecucion de la app
        Application.Quit();
    }
    //Salir al menu principal
    public void SalirAlMenu(){
        SceneManager.LoadScene("MenuPrincipal");
    }
    //Empezar y reintentar
    public void IniciarJuego(){
        SceneManager.LoadScene("EscenaJuego");
    }
}
