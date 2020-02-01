using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{

    public LineRenderer line;
    DistanceJoint2D joint;
    HingeJoint2D hingeJoint;
    Vector3 targetPos;
    RaycastHit2D hit;
    Rigidbody2D rb;
    Collider2D collider;
    public float distance = 50f;
    public LayerMask mask;
    public float grappleSpeed = 0.5f;
 
    public float disconnectDistance = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        joint = GetComponent<DistanceJoint2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        joint.enabled = false;
    }
    IEnumerator ToggleGravity()
    {
            rb.gravityScale = 0;
            yield return new WaitForSeconds(.5f);
            rb.gravityScale = 1;
    }

    
    private void Update()
    {


        if (joint.distance > disconnectDistance)
        {
            joint.distance -= grappleSpeed;
            line.SetPosition(0, transform.position);
        }
        else
        {
          
            DetachPlayer();
        }

        if (Input.GetMouseButton(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //targetPos.z = 0;
            line.enabled = true;
            line.SetPosition(1, transform.position);
            line.SetPosition(0, targetPos);

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (hit.collider != null)
            {
                joint.enabled = true;
                joint.connectedAnchor = targetPos;
                joint.distance = Vector2.Distance(transform.position, targetPos);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Debris"))
        {
            if (transform.GetChild(0).childCount > 0)
            {
                StartCoroutine(TogglePlayerCollider());
                transform.GetChild(0).GetChild(0).parent = null;
            }
         
            StartCoroutine( GetComponent<FlashOnHit>().Flash());
            DetachPlayer();
        }
    }

    IEnumerator TogglePlayerCollider() {
        //Stop us from picking up the gameobject again after hit
        collider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true;
    }

    public void DetachPlayer()
    {
        line.enabled = false;
        joint.enabled = false;
    }
}

