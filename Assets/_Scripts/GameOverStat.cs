using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverStat : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    [SerializeField]GameObject respawnBtn;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        respawnBtn.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            anim.SetTrigger("Down");
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            transform.GetComponent<Swing>().enabled = false;

            respawnBtn.GetComponent<Button>().GetComponentInChildren<Text>().text = $"You Repaired \n {GameManager.Instance.numberRepaired} \nSections \nRESPAWN";
            respawnBtn.SetActive(true);
        }
    }
}
