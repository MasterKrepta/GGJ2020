using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnHit : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Color original;
    [SerializeField] Color hitColor;
    [SerializeField] float flashTime = 0.3f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        original = sr.material.color;
    }

    public IEnumerator Flash()
    {
        anim.SetTrigger("Hurt");
        sr.color = hitColor;
        yield return new WaitForSeconds(flashTime);
        sr.color = original;
    }
}
