using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamaraBehaviourScript : MonoBehaviour
{
    //Variables para controlar tiempos
    float next_spawn_asteoroides;
    float next_spawn_enemigos;

    float next_spawn_enemigos2;
    float next_powerup_bala_doble;
    float next_spawn_powerup_vida;
    float next_spawn_powerup_bala_azul;


    //Objetos a instanciar
    public GameObject asteroide;
    public GameObject enemigos;

    public GameObject enemigos2;
    public GameObject powerup_bala_doble;

    public GameObject powerup_vida;

     public GameObject powerup2;
    
    SoundBehaviourScript script;

    void Start()
    {
         script = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundBehaviourScript>();
        
        next_spawn_asteoroides = Time.time + 1f;
        //aparece enemigo cada 5 segundos
        next_spawn_enemigos = Time.time + 1f;

        next_spawn_enemigos2 = Time.time + 4f;

        next_spawn_powerup_vida = Time.time + 10f;
        //aparece powerup cada 10 segundos
        next_powerup_bala_doble = Time.time + Random.Range(10f, 20f);

        next_spawn_powerup_bala_azul = Time.time + Random.Range(10f, 20f);
        PlayerPrefs.SetInt("puntos", 0);
        PlayerPrefs.SetInt("hits", 6);
        PlayerPrefs.SetInt("powerup_bala_doble_spawned", 0);
        PlayerPrefs.SetInt("powerup_bala_azul_spawned", 0);



    }

    void Update()
    {
        // Generar asteroides 
        if (Time.time > next_spawn_asteoroides)
        {
              int spawnSide = Random.Range(0, 4); // 0: Arriba, 1: Abajo, 2: Izquierda, 3: Derecha
              Vector2 spawnPosition = Vector2.zero;

        switch (spawnSide)
        {
            case 0: // Arriba
                spawnPosition = new Vector2(Random.Range(-7f, 7f), 4f); // Y positivo
                break;
            case 1: // Abajo
                spawnPosition = new Vector2(Random.Range(-7f, 7f), -4f); // Y negativo
                break;
            case 2: // Izquierda
                spawnPosition = new Vector2(-9f, Random.Range(-7f, 7f)); // X negativo
                break;
            case 3: // Derecha
                spawnPosition = new Vector2(12f, Random.Range(-7f, 7f)); // X positivo
                break;
            
        }

            Instantiate(asteroide, spawnPosition, Quaternion.identity);
                next_spawn_asteoroides = Time.time + 2f; 
        }

        // ENEMIGOS 1
        if (Time.time > next_spawn_enemigos)
        {

            int spawnSide = Random.Range(0, 4); // 0: Arriba, 1: Abajo, 2: Izquierda, 3: Derecha
              Vector2 spawnPosition = Vector2.zero;

          switch (spawnSide)
        {
            case 0: // Arriba
                spawnPosition = new Vector2(Random.Range(-8f, 8f), 6f); // Y positivo
                break;
            case 1: // Abajo
                spawnPosition = new Vector2(Random.Range(-8f, 8f), -6f); // Y negativo
                break;
            case 2: // Izquierda
            Debug.Log("entre a izquierda");
                spawnPosition = new Vector2(-8f, Random.Range(-4f, 4f)); // X negativo
                break;
            case 3: // Derecha
                Debug.Log("entre a derecha");

                spawnPosition = new Vector2(8f, Random.Range(-4f, 4f)); // X positivo
                break;
        }

            Instantiate(enemigos, spawnPosition, Quaternion.identity);
            next_spawn_enemigos = Time.time + 5f; 
            script.PlayAudioAsteroide(0);                   

        }

        if (Time.time > next_spawn_enemigos2)
        {

            int spawnSide = Random.Range(0, 4); // 0: Arriba, 1: Abajo, 2: Izquierda, 3: Derecha
              Vector2 spawnPosition = Vector2.zero;

          switch (spawnSide)
        {
            case 0: // Arriba
                spawnPosition = new Vector2(Random.Range(-8f, 8f), 6f); // Y positivo
                break;
            case 1: // Abajo
                spawnPosition = new Vector2(Random.Range(-8f, 8f), -6f); // Y negativo
                break;
            case 2: // Izquierda
                Debug.Log("entre a izquierda");
                spawnPosition = new Vector2(-8f, Random.Range(-4f, 4f)); // X negativo
                break;
            case 3: // Derecha
                 Debug.Log("entre a derecha");
                spawnPosition = new Vector2(8f, Random.Range(-4f, 4f)); // X positivo
                break;
        }

            Instantiate(enemigos2, spawnPosition, Quaternion.identity);
            next_spawn_enemigos2 = Time.time + 5f; 
            script.PlayAudioAsteroide(0);                   

        }

        //BALA DOBLE
        if (Time.time > next_powerup_bala_doble)
        {

            int powerup_bala_doble_spawned = PlayerPrefs.GetInt("powerup_bala_doble_spawned");
            Debug.Log("powerup_bala_doble_spawned: " + powerup_bala_doble_spawned);
            if(powerup_bala_doble_spawned == 0)
            {
                Instantiate(powerup_bala_doble, new Vector2(Random.Range(-7f, 7f),Random.Range(3, 0)), Quaternion.identity);
                next_powerup_bala_doble = Time.time + Random.Range(10f, 20f); // Actualizar el tiempo para el siguiente powerup
            }

        }
         //BALA AZUL 
        if(Time.time > next_spawn_powerup_bala_azul)
        {
            int powerup_bala_azul_spawned = PlayerPrefs.GetInt("powerup_bala_azul_spawned");
            Debug.Log("powerup_bala_azul_spawned: " + powerup_bala_azul_spawned);

            if (powerup_bala_azul_spawned == 0)
            {
                Instantiate(powerup2, new Vector2(Random.Range(-7f, 7f), Random.Range(3, 0)), Quaternion.identity);
                next_spawn_powerup_bala_azul = Time.time + Random.Range(10f, 20f); // Actualizar el tiempo para el siguiente powerup
            }
        }

        //VIDAS
        if (Time.time > next_spawn_powerup_vida)
        {
            int vidas = PlayerPrefs.GetInt("hits");
            Debug.Log("vidas: " + vidas);

            if (vidas < 6 )
            {
                Instantiate(powerup_vida, new Vector2(Random.Range(-7f, 7f), Random.Range(3, 0)), Quaternion.identity);
               next_spawn_powerup_vida = Time.time + Random.Range(10f, 20f); // Actualizar el tiempo para el siguiente powerup
           }
        }
    }

    


    public void RestartGame()
    {
       SceneManager.LoadScene(0);
    }
}
