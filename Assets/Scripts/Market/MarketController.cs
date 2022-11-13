using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MarketController : MonoBehaviour
{
    public GameObject counter;
    public GameObject marketUI;
    
    PlayerManager playerManager;

    //the distance required for player to open market
    public float distanceRequired;

    //if player is next to counter
    private bool isNextToCounter = false;
    //if the market menu is open
    private bool menuIsOpen = false;
    //player's distance from counter, default set to positive infinity
    private float distanceFromCounter = float.PositiveInfinity;

    void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //get and update the distance between player and counter
        distanceFromCounter = Vector3.Distance(counter.transform.position, gameObject.transform.position);

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
        if (Input.GetKeyDown(KeyCode.E) && isNextToCounter)
        {
            ToggleMarketUI();
        }
    }

    public void ToggleMarketUI()
    {
        if (!menuIsOpen)
        {
            //set market UI active
            //toggle boolean menuIsOpen
            //disable movement
            //disable camera movement
            marketUI.SetActive(true);
            menuIsOpen = !menuIsOpen;
            playerManager.pauseGame += 1;
        }
        else
        {
            marketUI.SetActive(false);
            menuIsOpen = !menuIsOpen;
            playerManager.pauseGame -= 1;
        }
    }
}
