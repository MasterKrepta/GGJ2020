using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomSprite : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, sprites.Length - 1);
        sr.sprite = sprites[rand];
    }

}
