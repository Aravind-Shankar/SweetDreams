using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]

public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    PlayerManager playerManager;

    private Transform loseText;
    private Transform winText;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        playerManager = FindObjectOfType<PlayerManager>();
        loseText = transform.Find("Fail");
        winText = transform.Find("Win");
        if (canvasGroup == null) {
            Debug.LogError("No Canvas Group added!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (canvasGroup.interactable) {
                CloseMenu();
            } else {
                OpenMenu();
            }
        }
    }

    public void OpenMenu() {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        playerManager.pauseGame += 1;

        Time.timeScale = 0f;
    }

    public void CloseMenu() {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        playerManager.pauseGame -= 1;

        Time.timeScale = 1f;
    }

    public void Lose() {
        OpenMenu();
        loseText.gameObject.SetActive(true);
    }

    public void Win() {
        OpenMenu();
        winText.gameObject.SetActive(true);
    }
}
