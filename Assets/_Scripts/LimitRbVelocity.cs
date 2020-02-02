using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitRbVelocity : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float maxVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Trying to Limit Speed
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
}
