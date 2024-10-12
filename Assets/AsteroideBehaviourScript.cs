using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideBehaviourScript : MonoBehaviour
{


    Vector2 asteroide_velocity;

     int hits;

     public Sprite asteroide2;
     public Sprite asteroide3;

    SoundBehaviourScript script;


    void Start()
    {
        Vector2 spawnPosition = transform.position;


        //obtener la velocidad del asteroide spawn position y segun la posicion del asteroide seguir esa direccion

        //si viene desde arriba
        if (spawnPosition.y > 0)
        {
            asteroide_velocity.y = -0.01f;
        }

        //si viene desde abajo
        if (spawnPosition.y < 0)
        {
            asteroide_velocity.y = 0.01f;
        }

        //si viene desde la izquierda

        if (spawnPosition.x < 0)
        {
            asteroide_velocity.x = 0.01f;
        }
        //si viene desde la derecha
        if (spawnPosition.x > 0)
        {
            asteroide_velocity.x = -0.01f;
        }
        // Escalar el asteroide el primer p
        float scale = Random.Range(0.5f, 1.5f);
        Vector2 asteroide_scale = new Vector2(scale, scale);
        transform.localScale = asteroide_scale;

        hits = 0;

        script = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundBehaviourScript>();

    }


    // Update is called once per frame
    void Update()
    {
     transform.Rotate(Vector3.back * 0.1f);


     int puntos = PlayerPrefs.GetInt("puntos");

    //  if (puntos > 10)
    //  {
    //      asteroide_velocity.y = -  0.02f;
    //  }
    //     if (puntos > 20)
    //     {
    //         asteroide_velocity.y = -0.05f;
    //     }
    // }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position += asteroide_velocity;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
     private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("AsteroideBehaviourScript.cs: onCollisionEnter2D: collision.gameObject.tag == " + collision.gameObject.tag);
        if (collision.gameObject.tag == "bullet" || collision.gameObject.tag == "disparo_tres")
        {

            Destroy(collision.gameObject);  // Destruir la bala


            Debug.Log("AsteroideBehaviourScript.cs: onCollisionEnter2D: collision.gameObject.tag == bullet");
            hits++;
            if (hits ==1)
            {

                GetComponent<SpriteRenderer>().sprite = asteroide2;


            }
            else if (hits == 2)
            {
                GetComponent<SpriteRenderer>().sprite = asteroide3;
            }
            else
            {

                script.PlayAudioAsteroide(1);                   
                int puntos = PlayerPrefs.GetInt("puntos");
                puntos++;
                PlayerPrefs.SetInt("puntos", puntos);

                if (puntos > PlayerPrefs.GetInt("record"))
                {
                    PlayerPrefs.SetInt("record", puntos);
                }


                Debug.Log("AsteroideBehaviourScript.cs: onCollisionEnter2D: puntos = " + puntos);
                Destroy(gameObject);
           }


        }

        if(collision.gameObject.tag == "disparo_azul")    
        {
            script.PlayAudioAsteroide(1);                   

            int puntos = PlayerPrefs.GetInt("puntos");
            puntos++;
            PlayerPrefs.SetInt("puntos", puntos);
             Destroy(collision.gameObject);  // Destruir la bala
             Destroy(gameObject);
        }   
    }

}
