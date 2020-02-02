using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomFallSpeed : MonoBehaviour
{
    float rand;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float rand = Random.Range(1, 5);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.down + new Vector2(0, rand));
    }
}
