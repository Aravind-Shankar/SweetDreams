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

    public void SetPotion(Potion potion)
    {
        _overallCanvasGroup.alpha = 1;

        potionIcon.sprite = potion.icon;
        potionNameText.text = potion.name;
        priceCanvasGroup.alpha = 1;
        potionPriceText.text = potion.sellingPrice.ToString();
    }
}
