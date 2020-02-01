using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

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
        }
    }

    private void OnDestroy()
    {
        if (isQuitting != true)
        {
            GameManager.Instance.CallOnDelivered();
        }

    }
  
      
    
}
