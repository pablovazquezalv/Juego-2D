using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    Vector2 velocidad_enemigo;



    // Start is called before the first frame update
    void Start()
    {
       //obtener la dirreccion de la bala 
        Vector2 spawnPosition = transform.position;

        //si viene de arriba
        if (spawnPosition.y > 0)
        {



                        velocidad_enemigo.y = 0.10f;


            
        }

        //si viene de abajo
        if (spawnPosition.y < 0)
        {

            //solo cambiar la BALA

                        velocidad_enemigo.y = -0.01f;

        }

      


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
         else if (collision.gameObject.tag == "disparo_azul")
        {
                Debug.Log("Colisión detectada con disparo_azul");

                Destroy(gameObject);
                //INCREMENTAR PUNTOS
                int puntos = PlayerPrefs.GetInt("puntos");
                puntos++;
                PlayerPrefs.SetInt("puntos", puntos);
                Destroy(collision.gameObject); // Destruir la bala}
                
        }

       
    }

    private void OnBecameInvisible()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
            Debug.Log("Se destruyo la bala");
        }
        else
        {
            Debug.Log("Error: BulletBehaviourScript.cs: OnBecameInvisible: gameObject is null");
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().position +=  velocidad_enemigo;
    }
}
