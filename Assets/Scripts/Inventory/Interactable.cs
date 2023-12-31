using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [Header("Interaction handling")]
    public string interactMessage = "Interact";
    public UnityEvent interactAction;

    [Header("Info display handling")]
    public bool infoActionPossible = true;
    public string infoTitle;
    [Multiline(6)]
    public string infoText;

    [HideInInspector]
    public bool playerIsInRange = false;

    private ControlsViewManager _controlsViewManager;
    private PauseMenuToggle _pauseMenuToggle;


    // Start is called before the first frame update
    void Start()
    {
        _controlsViewManager = FindObjectOfType<ControlsViewManager>();
        _pauseMenuToggle = FindObjectOfType<PauseMenuToggle>();
    }

    private void OnEnable()
    {
        EventManager.StartListening("Interact", PerformInteraction);
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
            _controlsViewManager.HoldPanel(KeyPanelType.Interact, interactMessage);
            if (infoActionPossible)
            {
                _pauseMenuToggle.SetInfoText(infoTitle, infoText);
                if (SceneManager.GetActiveScene().name == "Tutorial") 
                { 
                    _pauseMenuToggle.SetTutorialPanelText(infoTitle, infoText);
                }

                _controlsViewManager.HoldPanel(KeyPanelType.Info, "Details");
            }
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            playerIsInRange = false;
            _controlsViewManager.ReleasePanel(KeyPanelType.Interact);
            if (infoActionPossible)
            {
                _pauseMenuToggle.ResetInfoText();
                _controlsViewManager.ReleasePanel(KeyPanelType.Info);
            }   
        }
    }
}
