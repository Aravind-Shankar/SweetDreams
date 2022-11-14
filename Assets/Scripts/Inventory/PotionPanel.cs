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

    public void SetPotion(Potion potion)
    {
        _overallCanvasGroup.alpha = 1;
        _overallCanvasGroup.interactable = true;
        _overallCanvasGroup.blocksRaycasts = true;
        _potion = potion;

        potionIcon.sprite = potion.icon;
        potionNameText.text = potion.name;
        priceCanvasGroup.alpha = 1;
        potionPriceText.text = potion.sellingPrice.ToString();
    }

    public void ShowRecipe()
    {
        if (_potion == null)
        {
            Debug.LogError("Trying to show recipe of null potion!");
            return;
        }

        Color logColor = Color.blue, headerColor = Color.magenta;
        EventLog.Instance.AddLog($"*****************", headerColor);
        foreach (var pair in _potion.ingredientComposition)
        {
            EventLog.Instance.AddLog($"{ingredientSO.ingredients[pair.id].name} : {pair.count}x", logColor);
        }
        EventLog.Instance.AddLog("Dream Liquid (from Dream Machine)", logColor);
        EventLog.Instance.AddLog($"{_potion.name} recipe:", headerColor);
        EventLog.Instance.AddLog($"*****************", headerColor);
    }
}
