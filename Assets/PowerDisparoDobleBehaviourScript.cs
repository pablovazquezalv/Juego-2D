using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDisparoDobleBehaviourScript : MonoBehaviour
{

     Vector2 powerup_velocity;
    // Start is called before the first frame update
    void Start()
    {
       // powerup_velocity.y = .01f;

    }

    // Update is called once per frame
    void Update()
    {
        //eliminar despues de 10 segundos
        Destroy(gameObject, 10);
   
    }

    private void FixedUpdate()
    {
        //mover la bala
       // GetComponent <Rigidbody2D>().position -= powerup_velocity;
    }

     private void OnBecameInvisible()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
            Debug.Log("Se destruyo el powerup");

        }
        else
        {
            Debug.Log("Error: PowerUpBehaviourScript.cs: OnBecameInvisible: gameObject is null");
        }
    }

}
