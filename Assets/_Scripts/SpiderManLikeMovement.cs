using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderManLikeMovement : MonoBehaviour
{
    private State state;
    private enum State
    {
        Shooting,
        Swinging,Landing
    }

    private Vector3 targetPos;
    Vector3 targetDir;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Shooting:
                HandleShooting();
                break;
            case State.Swinging:
                HandleSwinging();
                break;
            case State.Landing:
                HandleLanding();
                break;
            default:
                break;
        }
    }

    private void HandleLanding()
    {
        throw new NotImplementedException();
    }

    private void HandleSwinging()
    {
        throw new NotImplementedException();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonUp(0))
        {
            targetPos = Camera.main.WorldToScreenPoint(Input.mousePosition);
            targetDir = (targetPos - transform.position).normalized;
            state = State.Shooting;
            transform.position += targetDir * speed * Time.deltaTime;
            if (Vector3.Distance(transform.position, targetPos) < 5f){
                //state = State.Swinging;
            }
            {

            }
        }
    }
}
