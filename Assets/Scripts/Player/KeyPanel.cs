using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CanvasGroup))]
public class KeyPanel : MonoBehaviour
{
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI keyDescText;
    public string keyName;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        keyText.text = keyName;
        SetState(false, "");
    }

    public void SetState(bool active, string desc = "")
    {
        _canvasGroup.alpha = active ? 1f : 0f;
        keyDescText.text = desc;
    }
}
