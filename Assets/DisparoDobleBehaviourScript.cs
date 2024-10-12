using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoDobleBehaviourScript : MonoBehaviour
{


    Vector2 bullet2_velocity;
    // Start is called before the first frame update
    void Start()
    {
        bullet2_velocity.x = 0;
        bullet2_velocity.y = 0.1f;

        

    }

    // Update is called once per frame
    void Update()
    {
       // GetComponent<Rigidbody2D>().position += bullet2_velocity;
        
    }
}
