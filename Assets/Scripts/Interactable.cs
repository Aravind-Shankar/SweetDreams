using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool playerIsInRange = false;
    public UnityEvent interactAction;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        EventManager.StartListening("Interact", PerformInteraction);
        Debug.Log("Listening");
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
