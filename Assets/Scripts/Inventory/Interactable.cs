using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string interactMessage = "Interact";
    public UnityEvent interactAction;
    public string infoMessage = "More Info";

    [HideInInspector]
    public bool playerIsInRange = false;

    private ControlsViewManager _controlsViewManager;


    // Start is called before the first frame update
    void Start()
    {
        _controlsViewManager = FindObjectOfType<ControlsViewManager>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("Interact", PerformInteraction);
        //EventManager.StartListening("ShowInfo", ShowInfo);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PerformInteraction()
    {
        if (playerIsInRange)
        {
            interactAction.Invoke();
        }
    }

    void ShowInfo()
    {
        if (playerIsInRange)
        {
            //showInfoAction.Invoke();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            playerIsInRange = true;
            _controlsViewManager.interactKeyPanel.SetState(interactMessage != "", interactMessage);
            _controlsViewManager.infoKeyPanel.SetState(infoMessage != "", infoMessage);
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            playerIsInRange = false;
            _controlsViewManager.interactKeyPanel.SetState(false);
            _controlsViewManager.infoKeyPanel.SetState(false);
        }
    }
}
