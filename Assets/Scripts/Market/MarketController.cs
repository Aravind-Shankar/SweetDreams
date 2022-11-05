using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MarketController : MonoBehaviour
{
    public GameObject counter;
    public GameObject marketUI;
    public CameraManager cameraManager;

    //the distance required for player to open market
    public float distanceRequired;

    //if player is next to counter
    public bool isNextToCounter = false;
    //if the market menu is open
    public bool menuIsOpen = false;
    //player's distance from counter, default set to positive infinity
    private float distanceFromCounter = float.PositiveInfinity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get and update the distance between player and counter
        distanceFromCounter = Vector3.Distance(counter.transform.position, gameObject.transform.position);
        print(counter.transform.position);
        print(gameObject.transform.position);

        if (distanceFromCounter < distanceRequired) {
            isNextToCounter = true;
        } else
        {
            isNextToCounter = false;
        }

        MarketContol();
    }

    // Open Market UI
    void MarketContol()
    {
        if (isNextToCounter)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!menuIsOpen)
                {
                    //set market UI active
                    //toggle boolean menuIsOpen
                    //disable camera movement
                    marketUI.SetActive(true);
                    menuIsOpen = !menuIsOpen;
                    cameraManager.pauseGame = true;
                } else
                {
                    marketUI.SetActive(false);
                    menuIsOpen = !menuIsOpen;
                    cameraManager.pauseGame = false;
                }
            }
        } else
        {
            marketUI.SetActive(false);
            cameraManager.pauseGame = false;
        }
    }
}
