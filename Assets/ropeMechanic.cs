using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeMechanic : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector2 moveDir = ((Vector2)transform.position - hit.point).normalized;

            rb.AddForce(moveDir * 50);
        }
    }
}
