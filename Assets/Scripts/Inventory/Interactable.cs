using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interactAction;
    public UnityEvent showInfoAction;

    [HideInInspector]
    public bool playerIsInRange = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        EventManager.StartListening("Interact", PerformInteraction);
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
            showInfoAction.Invoke();
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            playerIsInRange = true;
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            playerIsInRange = false;
        }
    }
}
