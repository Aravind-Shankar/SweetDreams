using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChamberHealthManager : MonoBehaviour
{
    public int maxHealth = 2;
    public MeshRenderer tintRenderer;
    public Color defaultColor;
    public Color zeroHealthColor;
    public GameObject statusPanel;
    public AudioSource healthAudio;

    private int _health;
    private bool _statusFlashing;
    private float _tintAlpha;
    private Inventory _inventory;
    private AudioSource audioSource;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        _health = maxHealth;
        _tintAlpha = tintRenderer.material.color.a;
        _statusFlashing = false;
        ShowHealthStatus();
        audioSource = GetComponent<AudioSource>();
        
    }

    private void ShowHealthStatus()
    {
        var currentColor = _health == 0 ? zeroHealthColor : defaultColor;
        tintRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, _tintAlpha);

        if (_health == 0)
        {
            audioSource.Play();
            if (!_statusFlashing)
            {
                InvokeRepeating(nameof(ToggleStatusPanel), 0f, 1f);
                _statusFlashing = true;
            }
        }
        else
        {
            CancelInvoke(nameof(ToggleStatusPanel));
            statusPanel.SetActive(false);
            _statusFlashing = false;
        }
    }

    private void ToggleStatusPanel()
    {
        statusPanel.SetActive(!statusPanel.activeSelf);
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
                healthAudio.Play();
            }
            else
            {
                EventLog.LogError("Health full already, can't feed food!");
            }
        }
        else
        {
            EventLog.LogError("No chamber food in hand!");
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
