using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBalaScript : MonoBehaviour
{


    Vector2 enemyball_velocity;



    // Start is called before the first frame update
    void Start()
    {
        enemyball_velocity.y = -.05f;
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
        GetComponent<Rigidbody2D>().position += enemyball_velocity;
    }
}
