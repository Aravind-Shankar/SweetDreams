using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class MarketIngredientPanel : MonoBehaviour
{
    public TextMeshProUGUI ingredientNameText;
    public TextMeshProUGUI ingredientDescriptionText;
    public TextMeshProUGUI ingredientPriceText;
    public Button buyButton;

    private CanvasGroup _overallCanvasGroup;
    private Ingredient _ingredient;
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<Inventory>();
        _overallCanvasGroup = GetComponent<CanvasGroup>();
        this.Clear();
    }

    public void Clear()
    {
        _overallCanvasGroup.alpha = 0;
        _overallCanvasGroup.interactable = false;
        _overallCanvasGroup.blocksRaycasts = false;

        _ingredient = null;
    }

    public void SetIngredient(Ingredient ingredient)
    {
        _overallCanvasGroup.alpha = 1;
        _overallCanvasGroup.interactable = true;
        _overallCanvasGroup.blocksRaycasts = true;

        ingredientNameText.text = ingredient.name;
        ingredientDescriptionText.text = ingredient.description;
        ingredientPriceText.text = ingredient.cost.ToString();

        _ingredient = ingredient;
    }

    public void BuyAndAdd()
    {
        if (_ingredient == null)
        {
            Debug.LogError("Trying to buy null ingredient!");
            return;
        }

        if (MoneySystem.Instance.Money < _ingredient.cost)
        {
            EventLog.LogError("Insufficient money to buy this item!");
        }
        else if (!_inventory.AddIngredient(_ingredient))
        {
            EventLog.LogError("Cannot add because no valid potion in hand!");
        }
        else
        {
            MoneySystem.Instance.Money -= _ingredient.cost;
            EventLog.LogInfo($"Bought & added one {_ingredient.name}!");
        }
    }
}
