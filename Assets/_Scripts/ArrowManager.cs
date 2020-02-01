using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager Instance;
    public GameObject Target;
    Transform Player;
    [SerializeField] Transform deliverySpot;
    [SerializeField] Image UpArrow;
    [SerializeField] Image DownArrow;
    public static Action OnPickup = delegate { };

    Vector2 screenBounds;
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        UpArrow.enabled = false;
        DownArrow.enabled = false;
        OnPickup += SetTargetToDelivery;
        GameManager.OnDelivered += SetTargetToPickup;
    }

    private void OnDisable()
    {
        OnPickup -= SetTargetToDelivery;
        GameManager.OnDelivered -= SetTargetToPickup;
    }

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        if (Target == null)
        {
            SetTargetToPickup();
        }
        if (Target.transform.position.y > Player.transform.position.y)
        {
            DownArrow.enabled = false;
            UpArrow.enabled = true;
        }
        else if (Target.transform.position.y < Player.transform.position.y)
        {
            DownArrow.enabled = true;
            UpArrow.enabled = false;

        }
        else 
        {
            print("hide arrows");
            DownArrow.enabled = false;
            UpArrow.enabled = false;
        }
    }

    public void SetTargetToPickup()
    {
        Target = FindObjectOfType<Pickup>().gameObject;
    }

    public void SetTargetToDelivery()
    {
        Target = deliverySpot.gameObject;
    }
}
