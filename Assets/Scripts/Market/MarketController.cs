using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketController : MonoBehaviour
{
    public GameObject counter;
    public GameObject marketUI;
    public IngredientSO ingredientSO;
    public RectTransform ingredientListContentTransform;
    public GameObject marketIngredientPanelPrefab;
    
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
        isNextToCounter = distanceFromCounter < distanceRequired;
        if (Input.GetKeyDown(KeyCode.E) && isNextToCounter)
        {
            ToggleMarketUI();
        }
    }

    private void PopulateIngredientListUI()
    {
        foreach (var ingredient in ingredientSO.ingredients)
        {
            GameObject ingredientPanelObject = Instantiate(marketIngredientPanelPrefab);
            ingredientPanelObject.transform.SetParent(ingredientListContentTransform);
            ingredientPanelObject.transform.localScale = Vector3.one;   // otherwise it gets scaled for some reason

            MarketIngredientPanel ingredientPanel = ingredientPanelObject.GetComponent<MarketIngredientPanel>();
            ingredientPanel.SetIngredient(ingredient); 
        }
    }

    private void ClearIngredientListUI()
    {
        for (int i = 0; i < ingredientListContentTransform.childCount; ++i)
        {
            Transform child = ingredientListContentTransform.GetChild(i);
            Destroy(child.gameObject);
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
            PopulateIngredientListUI();
            menuIsOpen = !menuIsOpen;
            playerManager.pauseGame += 1;
        }
        else
        {
            ClearIngredientListUI();
            marketUI.SetActive(false);
            menuIsOpen = !menuIsOpen;
            playerManager.pauseGame -= 1;
        }
    }
}
