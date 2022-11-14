using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class PotionPanel : MonoBehaviour
{
    public Image potionIcon;
    public TextMeshProUGUI potionNameText;
    public CanvasGroup priceCanvasGroup; 
    public TextMeshProUGUI potionPriceText;
    public IngredientSO ingredientSO;

    private CanvasGroup _overallCanvasGroup;
    private Potion _potion;

    private void Awake()
    {
        _overallCanvasGroup = GetComponent<CanvasGroup>();
        this.Clear();
    }

    public void Clear()
    {
        _overallCanvasGroup.alpha = 0;
        _overallCanvasGroup.interactable = false;
        _overallCanvasGroup.blocksRaycasts = false;
        _potion = null;
    }

    public void SetPotion(Potion potion, bool showPrice = true)
    {
        _overallCanvasGroup.alpha = 1;
        _overallCanvasGroup.interactable = true;
        _overallCanvasGroup.blocksRaycasts = true;
        _potion = potion;

        potionIcon.sprite = potion.icon;
        potionNameText.text = potion.name;

        if (showPrice)
        {
            priceCanvasGroup.alpha = 1;
            potionPriceText.text = potion.sellingPrice.ToString();
        }
        else
        {
            priceCanvasGroup.alpha = 0;
        }
    }

    public void ShowRecipe()
    {
        if (_potion == null)
        {
            Debug.LogError("Trying to show recipe of null potion!");
            return;
        }

        Color logColor = Color.blue, headerColor = Color.black;
        EventLog.LogInfo("-----------------");
        if (_potion.ingredientFrequency != null)
        {
            foreach (var pair in _potion.ingredientFrequency)
            {
                EventLog.Log($"{ingredientSO.ingredients[pair.Key].name} : {pair.Value}x", logColor);
            }
        }
        else
        {
            foreach (var pair in _potion.ingredientComposition)
            {
                EventLog.Log($"{ingredientSO.ingredients[pair.id].name} : {pair.count}x", logColor);
            }
        }
        
        EventLog.Log("Dream Liquid (from Dream Machine)", logColor);
        EventLog.Log($"{_potion.name} recipe:", headerColor);
        EventLog.LogInfo("-----------------");
    }
}
