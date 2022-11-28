using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum KeyPanelType
{
    Info,
    Interact,
    Drop
}

public class ControlsViewManager : MonoBehaviour
{
    [System.Serializable]
    public struct KeyPanelData
    {
        public KeyPanelType panelType;
        public KeyPanel keyPanel;
        public string defaultText;

        [HideInInspector]
        public bool held;

        public void Init()
        {
            held = false;
            keyPanel.SetState(defaultText != "", defaultText);
        }

        public void Hold(string text)
        {
            if (held)
                return;

            held = true;
            keyPanel.SetState(true, text);
        }

        public void Release()
        {
            if (!held)
                return;

            Init();
        }
    }

    [SerializeField]
    private KeyPanelData[] keyPanelData;

    private void Start()
    {
        foreach (var data in keyPanelData)
            data.Init();
    }

    public void HoldPanel(KeyPanelType panelType, string panelText)
    {
        foreach (var data in keyPanelData)
            if (data.panelType == panelType)
            {
                data.Hold(panelText);
                break;
            }
    }

    public void ReleasePanel(KeyPanelType panelType)
    {
        foreach (var data in keyPanelData)
            if (data.panelType == panelType)
            {
                data.Release();
                break;
            }
    }
}
