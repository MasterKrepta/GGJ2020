using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyColorOnActivaated : MonoBehaviour
{
    public Material SafeMaterial, DamagedMaterial;
    MeshRenderer mr;
    // Start is called before the first frame update
    private void OnEnable()
    {
        mr = GetComponent<MeshRenderer>();
        //GameManager.OnDelivered += DeactivateLights;
    }
    private void OnDisable()
    {
        //GameManager.OnDelivered -= DeactivateLights;
    }

    public void ActivateLights()
    {
 
       mr.material = DamagedMaterial;
    }


    public void DeactivateLights()
    {

        mr.material = SafeMaterial;
        
    }
}
