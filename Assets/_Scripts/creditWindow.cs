using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class creditWindow : MonoBehaviour
{
    public GameObject poppup;


    // Start is called before the first frame update
    public void windowActive()
    {

        if (poppup.activeInHierarchy)
        {
            poppup.SetActive(false);
        }
        else if (!poppup.activeInHierarchy)
        {
            poppup.SetActive(true);
        }
    }
}
