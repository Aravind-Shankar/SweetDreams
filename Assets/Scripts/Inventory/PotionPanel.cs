using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PotionPanel : MonoBehaviour
{
    public Image potionIcon;
    public TextMeshProUGUI potionNameText;
    public CanvasGroup priceCanvasGroup; 
    public TextMeshProUGUI potionPriceText;

    public PotionSO debug_PotionSO;

    private CanvasGroup _overallCanvasGroup;

    private void Start()
    {
        _overallCanvasGroup = GetComponent<CanvasGroup>();
        this.Clear();

        Invoke("DebugSetPotion", 2f);
    }

    private void DebugSetPotion()
    {
        this.SetPotion(debug_PotionSO.potions[0]);
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
