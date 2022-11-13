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

    private void Start()
    {
        _health = maxHealth;
        SetHealthText();
    }

    private void SetHealthText()
    {
        healthText.text = $"Health: {_health}/{maxHealth}";
        healthText.color = textColorGradient.Evaluate((float)(_health) / maxHealth);
    }

    public bool FeedFood()
    {
        // return true if fed successfully, false if not (e.g. when health is maxed)
        if (_health < maxHealth)
        {
            ++_health;
            SetHealthText();
            return true;
        }
        else
            return false;
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
