using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampPlayerToScreen : MonoBehaviour
{
    Vector2 screenBounds;
    float playerWidth;
    float playerHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
    // Update iUpdates called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + playerWidth, screenBounds.x * -1 - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + playerHeight, screenBounds.y * -1 - playerWidth);
        transform.position = viewPos;
    }
}
