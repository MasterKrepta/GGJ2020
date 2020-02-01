using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    public float smoothTime = 0.3f;
    public float posY, minX, maxX;

    Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.TransformPoint(new Vector3(0, posY, transform.position.z));
        Vector3 desiredPos = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(desiredPos.x, minX, maxX), desiredPos.y, desiredPos.z);
    }
}
