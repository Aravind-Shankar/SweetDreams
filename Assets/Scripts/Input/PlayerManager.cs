using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
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
        inputManager.HandleAllInputs();

        if (Input.GetKeyDown(KeyCode.Space))
            susBar.AddSus(5);
    }

    private void FixedUpdate() {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate() {
        cameraManager.HandleAllCameraMovement();
    }
}
