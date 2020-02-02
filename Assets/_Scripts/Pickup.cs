using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    AudioSource audio;
    [SerializeField] AudioClip[] PickupSounds;
    private void ProcessPickup()
    {
        GameManager.Instance.CallOnDelivered();
    }


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private bool isQuitting = false;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audio.clip = PickupSounds[UnityEngine.Random.Range(0, PickupSounds.Length - 1)];
            if (audio.clip != null)
            {
                audio.loop = false;
                audio.Play();

            }
            transform.parent = collision.transform.GetChild(0);
            ArrowManager.OnPickup();
        }
    }

    private void OnDestroy()
    {
        if (isQuitting != true)
        {
            
        }

    }
  
      
    
}
