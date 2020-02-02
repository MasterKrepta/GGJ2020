using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPickup : MonoBehaviour
{


    AudioSource audio;
    public AudioClip[] deliverSounds;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.loop = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            audio.clip = deliverSounds[UnityEngine.Random.Range(0, deliverSounds.Length - 1)];
            if (audio.clip != null)
            {
                audio.Play();
            }
            GameManager.OnDelivered();
            Destroy(collision.gameObject);
        }
    }
}
