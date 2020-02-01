using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverStat : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            anim.SetTrigger("Down");
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
        }
    }
}
