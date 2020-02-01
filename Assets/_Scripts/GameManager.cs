﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Transform[] spawnpoints;
    [SerializeField] Transform PickupPrefab;
    public static Action OnDelivered = delegate{ };
    public static int numberCollected = 0;


    private void OnEnable()
    {
       
        if (Instance == null)
        {
            Instance = this;
        }
        OnDelivered += IncreaseCollected;
        OnDelivered += spawnNewPickup;
    }
    private void OnDisable()
    {
        OnDelivered -= IncreaseCollected;
        OnDelivered -= spawnNewPickup;
    }

    public void CallOnDelivered()
    {
        OnDelivered();
    }

    void IncreaseCollected()
    {
   
        numberCollected++;
    }
    void spawnNewPickup()
    {
        int randSpawnPos = UnityEngine.Random.Range(0, spawnpoints.Length-1);
        

        Transform go =  Instantiate(PickupPrefab, spawnpoints[randSpawnPos].position, Quaternion.identity);
        go.position = new Vector3(go.position.x, go.position.y, 0);
    }


}
