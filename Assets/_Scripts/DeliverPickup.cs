using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            GameManager.OnDelivered();
            Destroy(collision.gameObject);
        }
    }
}
