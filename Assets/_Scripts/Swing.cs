using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
   
    public LineRenderer line;
    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    float distance = 100f;
    public LayerMask mask;
    public float grappleSpeed = 0.5f;
    public GameObject Building;
    public float disconnectDistance = 1f;

    private void Awake()
    {

        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
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
            line.enabled = false;
            joint.enabled = false;
           
        }
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //targetPos.z = 0;
            
            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);


            if (hit.collider != null)
            {
                //print($"we hit {hit.transform.name}");

                joint.enabled = true;
                //joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                //joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                joint.connectedAnchor = targetPos;
                joint.distance = Vector2.Distance(transform.position, targetPos);

                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, targetPos);
            }
        }

        //todo these controls let us cancel mid swing
        //if (Input.GetMouseButton(0))
        //{
        //    line.SetPosition(0, transform.position);
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    joint.enabled = false;
        //    line.enabled = false;
        //}
    }


}

