using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]

public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public CameraManager cameraManager;

    private Transform loseText;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        cameraManager = FindObjectOfType<CameraManager>();
        loseText = transform.Find("Fail");
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
        cameraManager.pauseGame = true;

        Time.timeScale = 0f;
    }

    public void CloseMenu() {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0f;
        cameraManager.pauseGame = false;

        Time.timeScale = 1f;
    }

    public void Lose() {
        OpenMenu();
        loseText.gameObject.SetActive(true);
    }
}
