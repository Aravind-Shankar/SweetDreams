using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChamberHealthManager : MonoBehaviour
{
    public int maxHealth = 2;
    public TextMeshProUGUI healthText;
    public Gradient textColorGradient;

    private int _health;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        _health = maxHealth;
        SetHealthText();
    }

    private void SetHealthText()
    {
        healthText.text = $"Health: {_health}/{maxHealth}";
        healthText.color = textColorGradient.Evaluate((float)(_health) / maxHealth);
    }

    public void FeedFood()
    {
        if (_inventory.GetItemType() == ItemType.chamberFood)
        {
            if (_health < maxHealth)
            {
                ++_health;
                SetHealthText();
                _inventory.RemoveItem();
            }
            else
            {
                EventLog.LogError("Health full already, can't feed food!");
            }
        }
        else
        {
            EventLog.LogError("Need to hold chamber food to feed the chamber!");
        }
    }

    public bool UseForDrink()
    {
        // return true if used successfully, false if not (e.g. when health is insufficient)
        if (_health == 0)
            return false;
        --_health;
        SetHealthText();
        return true;
    }
}
