using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBehaviourScript : MonoBehaviour
{

    public List<AudioClip> audios;

    public  AudioSource audio_nave;
    public AudioSource audio_asteroide;

    public AudioSource audio_disparo_azul;

    public AudioSource audio_choca_nave;

    public AudioSource audio_powerup_vida;

    public AudioSource audio_powerup_bala_doble;

    public AudioSource audio_powerup_bala_azul;

    public AudioSource audio_game_over;

    public AudioSource audio_soundtrack;

    public AudioSource audio_balas_enemigos;

    public AudioSource audio_choca_enemigo;
    void Start()
    {

        
    }

    void Update()
    {
        
    }


    public void PlayAudioNave(int indice)
    {
        audio_nave.PlayOneShot(audios[indice]);
    }

    public void PlayAudioAsteroide(int indice)
    {
        audio_asteroide.PlayOneShot(audios[indice]);
    }

    public void PlayAudioDisparoAzul(int indice)
    {
        audio_disparo_azul.PlayOneShot(audios[indice]);
    }

    public void PlayAudioChocaNave(int indice)
    {
        audio_choca_nave.PlayOneShot(audios[indice]);
    }

    public void PlayAudioPowerupVida(int indice)
    {
        audio_powerup_vida.PlayOneShot(audios[indice]);
    }

    public void PlayAudioPowerupBalaDoble(int indice)
    {
        audio_powerup_bala_doble.PlayOneShot(audios[indice]);
    }

    public void PlayAudioPowerupBalaAzul(int indice)
    {
        audio_powerup_bala_azul.PlayOneShot(audios[indice]);
    }

    public void PlayAudioGameOver(int indice)
    {
        audio_game_over.PlayOneShot(audios[indice]);
    }

    public void PlayAudioBalasEnemigos(int indice)
    {
        audio_balas_enemigos.PlayOneShot(audios[indice]);
    }

    public void PlayAudioEnemigoChocaNave(int indice)
    {
        audio_choca_enemigo.PlayOneShot(audios[indice]);
    }

    public void PlayAudioSoundtrack(int indice)
    {
        audio_soundtrack.PlayOneShot(audios[indice]);
    }

    //stop audio
    public void StopAudioSoundtrack()
    {
        audio_soundtrack.Stop();
    }
}
