using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioEvents : MonoBehaviour
{
    AudioSource audio;
    public AudioClip[] shootSound;
    public AudioClip[] hurtSound;
    public AudioClip[] Deathsound;
    

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.loop = false;

    }

   public void PlayShootSound()
    {
        audio.clip = shootSound[Random.Range(0, shootSound.Length-1)];
        if (audio.clip != null)
        {
            audio.Play();
        }
    }

    public void PlayHurtSound()
    {
        audio.clip = hurtSound[Random.Range(0, hurtSound.Length - 1)];
        if (audio.clip != null)
        {
            audio.Play();
        }
    }

    public void PlayDeathSound()
    {
        audio.clip = Deathsound[Random.Range(0, Deathsound.Length - 1)];
        if (audio.clip != null)
        {
            audio.Play();
        }
    }

  
        
}
