using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class PotionPanel : MonoBehaviour
{
    public Image potionIconUIImage;
    public TextMeshProUGUI potionNameText;
    public CanvasGroup priceCanvasGroup; 
    public TextMeshProUGUI potionPriceText;
    public TextMeshProUGUI currentIndicatorText;
    public IngredientSO ingredientSO;
    public PotionSO potionSO;

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
        currentIndicatorText.enabled = false;
    }

    public void SetPotion(Potion potion, bool showPrice = true)
    {
        _overallCanvasGroup.alpha = 1;
        _overallCanvasGroup.interactable = true;
        _overallCanvasGroup.blocksRaycasts = true;
        _potion = potion;

        potionIconUIImage.sprite = potionSO.potionIconBase;
        potionIconUIImage.color = new Color(potion.color.r, potion.color.g, potion.color.b, potionIconUIImage.color.a);
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

    public void SetAsCurrent()
    {
        currentIndicatorText.enabled = true;
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
                EventLog.Log($"{pair.Key} : {pair.Value}x", logColor);
            }
        }
        else
        {
            foreach (var pair in _potion.ingredientComposition)
            {
                EventLog.Log($"{pair.ingredientName} : {pair.count}x", logColor);
            }
        }
        
        EventLog.Log("Dream Liquid (from Dream Machine)", logColor);
        EventLog.Log($"{_potion.name} recipe:", headerColor);
        EventLog.LogInfo("-----------------");
    }
}
