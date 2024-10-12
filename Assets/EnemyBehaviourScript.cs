using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    Vector2 enemy_velocity;
    public GameObject eball; // Prefab de la bala
    public float bulletSpeed = 5f; // Velocidad de la bala

    float next_spawn_eball;
    float next_move_enemy;
    int par_impares;  // Alternar entre moverse a la izquierda y derecha
    int hits_enemy;

    SoundBehaviourScript script;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 spawnPosition = transform.position; // Movimiento inicial hacia abajo

        // Si viene de arriba
        if (spawnPosition.y > 0)
        {
            enemy_velocity.y = -0.01f;  // El enemigo se mueve hacia abajo
        }

        // Si viene de abajo
        if (spawnPosition.y < 0)
        {
            transform.Rotate(0, 0, 180);  // Rotar la nave si viene de abajo
            enemy_velocity.y = 0.01f;  // El enemigo se mueve hacia arriba
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
            // Instanciar la bala
            GameObject bullet = Instantiate(eball, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Determinar la dirección de la bala dependiendo de la posición del enemigo
            if (transform.position.y > 0)
            {
                // El enemigo viene de arriba, disparar hacia abajo
                bulletRb.velocity = new Vector2(0, -bulletSpeed);
            }
            else if (transform.position.y < 0)
            {
                // El enemigo viene de abajo, disparar hacia arriba
                bulletRb.velocity = new Vector2(0, bulletSpeed);
            }

            next_spawn_eball += 3f;
            script.PlayAudioBalasEnemigos(9);
        }

        // Lógica para mover el enemigo hacia la izquierda o derecha en intervalos
        if (Time.time > next_move_enemy)
        {
            if (par_impares % 2 == 0)
            {
                // enemy_velocity.x = +0.02f;  // Mover a la derecha
            }
            else
            {
                // enemy_velocity.x = -0.02f;  // Mover a la izquierda
            }

            par_impares++;  // Alternar la dirección
            next_move_enemy += 0.8f;  // Tiempo entre cada cambio de dirección
        }
    }

    // Función para manejar colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        else if (collision.gameObject.tag == "disparo_azul")
        {
            script.PlayAudioEnemigoChocaNave(10);
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
