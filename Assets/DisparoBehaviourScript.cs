using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBehaviourScript : MonoBehaviour
{
    //declarar la velocidad de la bala
        Vector2 bullet_velocity;

    void Start()
    {
        float num2 = PlayerPrefs.GetFloat("num2");
        float num3 = PlayerPrefs.GetFloat("num3");

        bullet_velocity.x = num2;
        bullet_velocity.y = num3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //mover la bala
        GetComponent <Rigidbody2D>().position += bullet_velocity;
    }

    //ELIMINAR LA BALA CUANOD
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

   
    
}
