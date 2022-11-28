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
    private ControlsViewManager _controlsViewManager;
    private PauseMenuToggle _pauseMenuToggle;

    //the distance required for player to open market
    public float distanceRequired;

    [Header("Info display handling")]
    public string infoTitle;
    [Multiline(6)]
    public string infoText;

    //if player is next to counter
    private bool isNextToCounter = false;
    //if the market menu is open
    private bool menuIsOpen = false;
    //player's distance from counter, default set to positive infinity
    private float distanceFromCounter = float.PositiveInfinity;

    void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        _controlsViewManager = FindObjectOfType<ControlsViewManager>();
        _pauseMenuToggle = FindObjectOfType<PauseMenuToggle>();
    }

    // Update is called once per frame
    void Update()
    {
        //get and update the distance between player and counter
        distanceFromCounter = Vector3.Distance(counter.transform.position, gameObject.transform.position);
        if (distanceFromCounter < distanceRequired)
        {
            if (!isNextToCounter)
            {
                isNextToCounter = true;
                _pauseMenuToggle.SetInfoText(infoTitle, infoText);
                _controlsViewManager.HoldPanel(KeyPanelType.Interact, "Shop for ingredients");
                _controlsViewManager.HoldPanel(KeyPanelType.Info, "Details");
            }

            if (Input.GetKeyDown(KeyCode.E) && !_pauseMenuToggle.IsPaused())
                ToggleMarketUI();
        }
        else if (isNextToCounter)
        {
            isNextToCounter = false;
            _pauseMenuToggle.ResetInfoText();
            _controlsViewManager.ReleasePanel(KeyPanelType.Interact);
            _controlsViewManager.ReleasePanel(KeyPanelType.Info);
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
            marketUI.SetActive(true);
            PopulateIngredientListUI();
            menuIsOpen = !menuIsOpen;
            playerManager.pauseGame += 1;
            _pauseMenuToggle.inMarket = true;
        }
        else
        {
            ClearIngredientListUI();
            marketUI.SetActive(false);
            menuIsOpen = !menuIsOpen;
            playerManager.pauseGame -= 1;
            _pauseMenuToggle.inMarket = false;
        }
    }
}
