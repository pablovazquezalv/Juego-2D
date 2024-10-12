using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipBehaviourScript : MonoBehaviour
{

    Vector2 ship_velocity;

    public GameObject bulletPrefab, bullet2,bullet3;

    public GameObject button;


    public GameObject corazon1, corazon2, corazon3, corazon4, corazon5;

    int hits;

    int tipo_disparo;

    public SoundBehaviourScript script;


    // Start is called before the first frame update
    void Start()
    {
        hits = 6;
        tipo_disparo = 0;
        PlayerPrefs.SetString("disparo", "Disparo normal");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!script.audio_soundtrack.isPlaying)
        {
            script.PlayAudioSoundtrack(8);  // Play the soundtrack again
        }
        // Mover la nave en el eje x
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ship_velocity.x = -0.1f;
        }
        // Mover la nave en el eje x
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ship_velocity.x = +.1f;
        }
        // Mover la nave en el eje y
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ship_velocity.y = +.1f;
        }
        // Mover la nave en el eje y
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ship_velocity.y = -0.1f;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            ship_velocity.x = 0;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            ship_velocity.y = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
           //rotar nave
            transform.Rotate(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            //rotar nave
            transform.Rotate(0, 0, -1);
        }
       
        // Disparar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            float angulo = Mathf.Round(transform.eulerAngles.z);
            Debug.Log("SpaceShipBehaviourScript.cs: Update: angulo = " + angulo);

            if(angulo >= 0 && angulo <= 90)
            {
                float num1 = (angulo*100) / 90;
                float num2 = (num1 * 1) / 100;
                float num3 = 1 - num2;

                PlayerPrefs.SetFloat("num1", num1);
                PlayerPrefs.SetFloat("num2", -num2);
                PlayerPrefs.SetFloat("num3", num3);
            }

            if (angulo > 90 && angulo <= 180)
            {
                 float num1 = ((angulo-90)*100) / 90;
                float num2 = (num1 * 1) / 100;
                float num3 = 1 - num2;

                PlayerPrefs.SetFloat("num1", num1);
                PlayerPrefs.SetFloat("num2", -num3);
                PlayerPrefs.SetFloat("num3", -num2);
            }

            if (angulo > 180 && angulo <= 270)
            {
                float num1 = ((angulo-180)*100) / 90;
                float num2 = (num1 * 1) / 100;
                float num3 = 1 - num2;

                PlayerPrefs.SetFloat("num1", num1);
                PlayerPrefs.SetFloat("num2", num2);
                PlayerPrefs.SetFloat("num3", -num3);
            }


            if (angulo > 270 && angulo <= 360)
            {
                float num1 = ((angulo-270)*100) / 90;
                float num2 = (num1 * 1) / 100;
                float num3 = 1 - num2;

                PlayerPrefs.SetFloat("num1", num1);
                PlayerPrefs.SetFloat("num2", num3);
                PlayerPrefs.SetFloat("num3", num2);
            }

            if (tipo_disparo == 0)
            {
                script.PlayAudioNave(0);
                Instantiate(bulletPrefab, transform.position, transform.rotation);

            }
            else if (tipo_disparo == 1)
            {
               script.PlayAudioNave(0);
                Debug.Log("SpaceShipBehaviourScript.cs: Update: tipo_disparo = " + tipo_disparo);
                Instantiate(bullet2, transform.position, transform.rotation);
            }

            else if (tipo_disparo == 2)
            { 
                script.PlayAudioDisparoAzul(2);
                Debug.Log("SpaceShipBehaviourScript.cs: Update: tipo_disparo = " + tipo_disparo);
                Instantiate(bullet3, transform.position, transform.rotation);
            }

        }
        
    }

    private void FixedUpdate()
    {
        GetComponent <Rigidbody2D>().position += ship_velocity;
    } 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("[SpaceShip] Colision con: " + collision.gameObject.tag);

        if(collision.gameObject.tag == "powerup_vida")
        {
            script.PlayAudioPowerupVida(4);
            hits = 6;
            Debug.Log("hits = " + hits);
            PlayerPrefs.SetInt("hits", hits);

            //se destruye el powerup
            Destroy(collision.gameObject);
            if (hits == 6)
            {
                corazon5.SetActive(true);
                corazon1.SetActive(true);
                corazon2.SetActive(true);
                corazon3.SetActive(true);
                corazon4.SetActive(true);
                
            }
            if (hits == 5)
            {
                corazon4.SetActive(true);
            }
            if (hits == 4)
            {
                corazon3.SetActive(true);
            }
            if (hits == 3)
            {
                corazon2.SetActive(true);
            }
            if (hits == 2)
            {
                corazon1.SetActive(true);
            }

            if (hits == 1)
            {
                corazon1.SetActive(true);
            }

        }

        if(collision.gameObject.tag == "powerup_bala_doble")
        {
            script.PlayAudioPowerupBalaDoble(5);
            tipo_disparo = 1;
            PlayerPrefs.SetString("disparo", "Disparo doble");
            //se destruye el powerup
            Destroy(collision.gameObject); 
            PlayerPrefs.SetInt("powerup_bala_doble_spawned", 1);
            PlayerPrefs.SetInt("powerup_bala_azul_spawned", 0);

        }


        if(collision.gameObject.tag == "powerup_disparo_azul")
        {
            PlayerPrefs.SetString("disparo", "Disparo azul");
            script.PlayAudioPowerupBalaAzul(6);
            tipo_disparo = 2;
            PlayerPrefs.SetInt("powerup_bala_doble_spawned", 0);
            PlayerPrefs.SetInt("powerup_bala_azul_spawned", 1);

            //se destruye el powerup
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "asteroide" || collision.gameObject.tag == "eball")
        {
            script.PlayAudioChocaNave(3);

            hits--;
            Debug.Log("hits despues de chocar con enemy o asteroide = " + hits);
            PlayerPrefs.SetInt("hits", hits);
            PlayerPrefs.SetInt("powerup_bala_doble_spawned", 0);
            PlayerPrefs.SetInt("powerup_bala_azul_spawned", 0); 

            Destroy(collision.gameObject);  // Destruir la bala
            tipo_disparo = 0;


           // GetComponent<AudioSource>().PlayOneShot(audio_choque);
            if (hits == 5)
            {
                corazon5.SetActive(false);
            }
            if (hits == 4)
            {
                corazon4.SetActive(false);
            }
            if (hits == 3)
            {
                corazon3.SetActive(false);
            }
            if (hits == 2)
            {
                corazon2.SetActive(false);
            }
            if (hits == 1)
            {
                corazon1.SetActive(false);
            }
            if (hits == 0)
            {
                Destroy(gameObject);
                //detener la musica de fondo de mainCamera

                 script.StopAudioSoundtrack();
            
                script.PlayAudioGameOver(7);
                button.SetActive(true);
            }
        }

        if(collision.gameObject.tag == "enemigo_nave")
        {
            hits = 0;
            Destroy(gameObject);

            script.StopAudioSoundtrack();
            
            script.PlayAudioGameOver(7);

            button.SetActive(true);
        }
    }

    
   

   
}
