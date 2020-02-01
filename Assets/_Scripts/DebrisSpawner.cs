using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    [SerializeField] Transform debris;
    [SerializeField] float spawnRate = 2.5f;
    float nextSpawntime = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void Spawn()
    {

        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width),  Screen.height/* Random.Range(0, Screen.height)*/, /*Camera.main.farClipPlane / 2*/0));
        screenPosition.z = 0;
        screenPosition.y = 155; //todo this is hacky
       Instantiate(debris, screenPosition, Quaternion.identity);
        
    }
}

