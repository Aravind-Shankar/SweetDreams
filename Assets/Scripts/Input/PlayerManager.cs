using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int pauseGame = 0;

    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    CameraManager cameraManager;

    SusBar susBar;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        cameraManager = FindObjectOfType<CameraManager>();

        susBar = FindObjectOfType<SusBar>();
    }

    private void Update()
    {
        if (pauseGame < 0)
            Debug.LogError("PauseGame value should not be below 0.");

        inputManager.HandleAllInputs(pauseGame == 0);
    }

    private void FixedUpdate() {
        playerLocomotion.HandleAllMovement(pauseGame == 0);
    }

    private void LateUpdate() {
        if (pauseGame == 0)
            cameraManager.HandleAllCameraMovement();
    }
}
