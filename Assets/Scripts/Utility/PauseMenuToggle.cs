using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]

public class PauseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public CameraManager cameraManager;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
        cameraManager = FindObjectOfType<CameraManager>();
        if (canvasGroup == null) {
            Debug.LogError("No Canvas Group added!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) {
            if (canvasGroup.interactable) {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;
                cameraManager.pauseGame = false;

                Time.timeScale = 1f;
            } else {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;
                cameraManager.pauseGame = true;

                Time.timeScale = 0f;
            }
        }
    }
}
