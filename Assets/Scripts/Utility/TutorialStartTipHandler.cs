using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialStartTipHandler : MonoBehaviour
{
    private bool alreadyShownToPlayer;
    private PauseMenuToggle pauseMenuToggle;

    private void Awake()
    {
        alreadyShownToPlayer = false;
        pauseMenuToggle = FindObjectOfType<PauseMenuToggle>();

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
