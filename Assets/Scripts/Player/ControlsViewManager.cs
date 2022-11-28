using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsViewManager : MonoBehaviour
{
    public KeyPanel infoKeyPanel;
    public KeyPanel interactKeyPanel;
    public KeyPanel dropKeyPanel;

    private void Start()
    {
        infoKeyPanel.SetState(false);
        interactKeyPanel.SetState(false);
        dropKeyPanel.SetState(false);
    }
}
