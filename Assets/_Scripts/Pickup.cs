using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    private void ProcessPickup()
    {
        GameManager.Instance.CallOnDelivered();
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
