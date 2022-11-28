using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string interactMessage = "Interact";
    public UnityEvent interactAction;
    public bool infoActionPossible = true;

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
        if (infoActionPossible)
            EventManager.StartListening("ShowInfo", ShowInfo);
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
            _controlsViewManager.interactKeyPanel.SetState(true, interactMessage);
            _controlsViewManager.infoKeyPanel.SetState(infoActionPossible, "More Info");
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
