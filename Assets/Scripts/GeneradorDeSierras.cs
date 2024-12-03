using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeSierras : MonoBehaviour
{

    [SerializeField]
    public GameObject sierraASpawnear;      //El GamObject de las sierras
    [SerializeField]
    public float tiempoEsperaSpawn;         //El tiempo de espera de generacion de las sierras desde que se inicia el lanzador
    [SerializeField]
    public float intervaloDeSpawn;          //El intervalo en el que se generan
    [SerializeField]
    float minX=-4f;                         //La distancia x hacia la izquierda del spawner
    [SerializeField]
    float maxX=4f;                          //La distancia x hacia la derecha del spawner

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }


    //Funcion para spawnear las sierras
    void Spawn(){
        //generar posicion x aleatoria
        float randomX=Random.Range(minX,maxX);
        //generar vector2d en la ex aleatoria y en mi y
        Vector2 spawnPos=new Vector2(randomX,transform.position.y);
        Instantiate(sierraASpawnear,spawnPos,Quaternion.identity);
    }

    //Empezar a spawnear las sierras
    void StartSpawning(){
        InvokeRepeating("Spawn",tiempoEsperaSpawn,intervaloDeSpawn);
    }

    //Cancelar el Spawn de sierras
    public void StopSpawning(){
        CancelInvoke("Spawn");
    }

    // Aumentar la velocidad a la que aparecen las sierras
     public void AumentarVelocidadSpawn()
    {
        // Reducir el intervalo de spawn
        intervaloDeSpawn *= 0.9f; 
        // Reiniciar la llamada de InvokeRepeating con el nuevo intervalo
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", intervaloDeSpawn/4, intervaloDeSpawn);
    }


}
