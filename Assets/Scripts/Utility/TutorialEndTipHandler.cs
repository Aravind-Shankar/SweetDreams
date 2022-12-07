using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEndTipHandler : MonoBehaviour
{
    [Header("Tutorial text display handling")]
    public string tutorialTitle;
    [Multiline(6)]
    public string tutorialText;

    private bool alreadyShownToPlayer;
    private PauseMenuToggle pauseMenuToggle;

    private TutorialPathRenderer tutorialPathRenderer;
    public int pointOfInterestId;
    private void Awake()
    {
        alreadyShownToPlayer = false;
        pauseMenuToggle = FindObjectOfType<PauseMenuToggle>();
        tutorialPathRenderer = FindObjectOfType<TutorialPathRenderer>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Tutorial" && pointOfInterestId == tutorialPathRenderer.currentPointOfInterest && !alreadyShownToPlayer)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                pauseMenuToggle.SetTutorialPanelText(tutorialTitle, tutorialText);
                pauseMenuToggle.OpenTutorialTip();
                alreadyShownToPlayer = true;
            }
        }
    }
}
