using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChamberHealthManager : MonoBehaviour
{
    public int maxHealth = 2;
    public MeshRenderer tintRenderer;
    public Color defaultColor;
    public Color zeroHealthColor;

    private int _health;
    private float _tintAlpha;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        _health = maxHealth;
        _tintAlpha = tintRenderer.material.color.a;
        ShowHealthStatus();
    }

    private void ShowHealthStatus()
    {
        var currentColor = _health == 0 ? zeroHealthColor : defaultColor;
        tintRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, _tintAlpha);
    }

    public void FeedFood()
    {
        if (_inventory.GetItemType() == ItemType.chamberFood)
        {
            if (_health < maxHealth)
            {
                _health = maxHealth;
                ShowHealthStatus();
                _inventory.RemoveItem();

                EventLog.LogInfo("Fed food to chamber.");
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
        ShowHealthStatus();
        return true;
    }
}
