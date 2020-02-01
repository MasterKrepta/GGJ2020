using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPlayerToScreen : MonoBehaviour
{
    Vector2 screenBounds;
    float playerWidth;
    float playerHeight;
    Camera MainCamera;

    private void Start()
    {
        MainCamera = Camera.main;
        
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
    // Update iUpdates called once per frame
    void LateUpdate()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, (screenBounds.x - playerWidth) * - 1, screenBounds.x - playerWidth),
                                         Mathf.Clamp(transform.position.y, (screenBounds.y - playerHeight) * -1, screenBounds.y - playerHeight),
                                         0);
    }
}