using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{

    public LineRenderer line;
    DistanceJoint2D joint;
    //SpringJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    Animator anim;
    Rigidbody2D rb;
    Collider2D collider;
    public float distance = 50f;
    public LayerMask mask;
    public float grappleSpeed = 0.5f;
    public float maxVelocity = 10f;
    bool isFacingRight = true;
    public float maxDistance = 20;
    public float disconnectDistance = 2f;

    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        joint = GetComponent<DistanceJoint2D>();
        //joint = GetComponent<SpringJoint2D>();
        joint.enabled = false;
        line.enabled = false;
    }
   
    private void Update()
    {
        

        if (joint.distance > disconnectDistance)
        {
           // joint.enabled = true;
            joint.distance -= grappleSpeed;
            line.enabled = false;

        }
        else
        {
          
            DetachPlayer();
        }

        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("Shooting");
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //targetPos.z = 0;

            if (transform.position.x < targetPos.x && !isFacingRight)
            {
                FlipSprite();
            }
            else if (transform.position.x > targetPos.x && isFacingRight)
            {
                FlipSprite();
            }
           
            line.enabled = true;
            line.SetPosition(1, transform.position);
            line.SetPosition(0, targetPos);

           // hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);
            hit = Physics2D.Raycast(targetPos, targetPos - transform.position, distance, mask);
        }

        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = true;
            if (hit.collider != null)
            {
                anim.StopPlayback();
                anim.SetTrigger("Pull");
              
                
                joint.connectedAnchor = targetPos;
                joint.connectedBody = hit.collider.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);
                joint.distance = Mathf.Clamp(joint.distance, 0, maxDistance);

               
            }
        }
    }
    void FlipSprite()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void FixedUpdate()
    {
        //rb.velocity = Vector2.ClampMagnitude(rb.velocity.magnitude, maxVelocity);
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
        yield return new WaitForSeconds(0.2f);
        collider.enabled = true;
    }

    public void DetachPlayer()
    {
        line.enabled = false;
        joint.enabled = false;
    }
}

