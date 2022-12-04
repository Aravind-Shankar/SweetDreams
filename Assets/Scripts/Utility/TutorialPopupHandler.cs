using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPopupHandler : MonoBehaviour
{

    private Transform tutorialPanel;

    private PauseMenuToggle pauseMenuToggle;
    private bool alreadyShownToPlayer;
    void Awake()
    {
        tutorialPanel = transform.Find("TutorialPanel");
        pauseMenuToggle = FindObjectOfType<PauseMenuToggle>();
        alreadyShownToPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().name == "Tutorial" && !alreadyShownToPlayer)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                pauseMenuToggle.OpenTutorialTip();
                alreadyShownToPlayer = true;
            }
        }

    }
}
