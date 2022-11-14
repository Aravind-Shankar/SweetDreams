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

    private void Awake()
    {
        _overallCanvasGroup = GetComponent<CanvasGroup>();
        this.Clear();
    }

    public void Clear()
    {
        _overallCanvasGroup.alpha = 0;
    }

    public void SetIngredient(Ingredient ingredient)
    {
        _overallCanvasGroup.alpha = 1;

        ingredientNameText.text = ingredient.name;
        ingredientDescriptionText.text = ingredient.description;
        ingredientPriceText.text = ingredient.cost.ToString();
    }
}
