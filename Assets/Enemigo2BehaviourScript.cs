using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2BehaviourScript : MonoBehaviour
{
    Vector2 enemy_velocity;
    public GameObject eball;
    float next_spawn_eball;
    public float bulletSpeed = 5f; 
    float next_move_enemy;
    int par_impares;  // Alternar entre moverse a la izquierda y derecha
    int hits_enemy;
    int dirección;

    SoundBehaviourScript script;

    void Start()
    {

        Vector2 spawnPosition =  transform.position;
        dirección = 0;

        if (spawnPosition.y == 6f && spawnPosition.x >= -8f && spawnPosition.x <= 8f)
        {
            enemy_velocity.y = -0.01f;  
            dirección = 1;
            Debug.Log("Viene de arriba");
        }

        // Si viene de abajo (Y negativo)
        if (spawnPosition.y == -6f && spawnPosition.x >= -8f && spawnPosition.x <= 8f)
        {
            transform.Rotate(0, 0, 180);  // Rotar la nave si viene de abajo
            enemy_velocity.y = 0.01f;  // El enemigo se mueve hacia arriba
            dirección = 2;
            Debug.Log("Viene de abajo");
        }

        // Si viene de la izquierda (X negativo)
        if (spawnPosition.x == -8f && spawnPosition.y >= -4f && spawnPosition.y <= 4f)
        {
            transform.Rotate(0, 0, 90);  
            enemy_velocity.x = 0.01f;  // El enemigo se mueve hacia la derecha
            dirección = 3;
            Debug.Log("Viene de la izquierda");
        }

        if (spawnPosition.x == 8f && spawnPosition.y >= -4f && spawnPosition.y <= 4f)
        {
            transform.Rotate(0, 0, -90);  
            enemy_velocity.x = -0.01f; 
            dirección = 4;
            Debug.Log("Viene de la derecha");
        }

        next_spawn_eball = Time.time + 1f;  // Primer disparo después de 1 segundo
        next_move_enemy = Time.time + 0.5f; // Movimiento después de 0.5 segundos
        par_impares = 1;
        hits_enemy = 0;

        // Obtener el script de sonido del objeto con la etiqueta "sound"
        script = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundBehaviourScript>();
  
        
    }

    // Update is called once per frame
      void Update()
    {
        // Lógica para disparar balas del enemigo en intervalos
        if (Time.time > next_spawn_eball)
        {
              GameObject bullet = Instantiate(eball, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                          bulletRb.gravityScale = 0;

           if (dirección == 1)
            {
                //rotar la bala
                bullet.transform.Rotate(0, 0, 0);
                bulletRb.velocity = new Vector2(0, -bulletSpeed);
        
            }
            if (dirección == 2)
            {
                bullet.transform.Rotate(0, 0, 180);
                bulletRb.velocity = new Vector2(0, bulletSpeed);
            }
            if (dirección == 3)
            {
                //rotar la bala
                bullet.transform.Rotate(0, 0, 90);


                bulletRb.velocity = new Vector2(bulletSpeed,0);
            }
            if (dirección == 4)
            {
                //rotar la bala
                bullet.transform.Rotate(0, 0, -90);
                bulletRb.velocity = new Vector2(-bulletSpeed, 0);
            }

            next_spawn_eball += 1f;  // Tiempo entre cada disparo
         if (Time.time > next_move_enemy)
        {
            if (par_impares % 2 == 0)
            {
                 if(dirección == 1 || dirección == 2)
                 {
                    enemy_velocity.x = -0.02f;  // Mover a la izquierda

                 }
                 else
                 {
                                        enemy_velocity.y = -0.02f;  // Mover hacia abajo

                 }

            }
            else
            {
                if(dirección == 1 || dirección == 2)
                {
                                        enemy_velocity.x = +0.02f;  // Mover a la derecha

                }
                else
                {
                                        enemy_velocity.y = +0.02f;  // Mover hacia arriba

                }
            }

            par_impares++;  // Alternar la dirección
            next_move_enemy += 0.8f;  // Tiempo entre cada cambio de dirección
        }
    }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("Colisión con: " + collision.gameObject.tag);
            
            if (collision.gameObject.tag == "bullet")
            {
                hits_enemy++; 
                script.PlayAudioEnemigoChocaNave(10);  
                Destroy(collision.gameObject);  // Destruir la bala

                // Si el enemigo ha recibido 5 impactos, se destruye
                if (hits_enemy == 5)
                {
                    Destroy(gameObject);  // Destruir el enemigo
                    int puntos = PlayerPrefs.GetInt("puntos");
                    puntos += 5;  // Incrementar los puntos
                    PlayerPrefs.SetInt("puntos", puntos);
                    hits_enemy = 0;  // Reiniciar los impactos
                }
            }
            // Si el enemigo colisiona con "disparo_azul"
            else if (collision.gameObject.tag == "disparo_azul")
            {
                Debug.Log("Colisión detectada con disparo_azul");
                script.PlayAudioEnemigoChocaNave(10);  // Reproducir sonido de colisión
                Destroy(gameObject);  // Destruir el enemigo
                int puntos = PlayerPrefs.GetInt("puntos");
                puntos += 5;  // Incrementar los puntos
                PlayerPrefs.SetInt("puntos", puntos);
                Destroy(collision.gameObject);  // Destruir la bala azul
            }
    }

    // Movimiento del enemigo
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += enemy_velocity;
    }

    // Destruir el enemigo cuando sale de la pantalla
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}
    

