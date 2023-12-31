using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;

    public Vector2 cameraInput;
    public Vector2 movementInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool b_Input;
    private bool interactInput;
    private bool dropInput;
    private bool showInfoInput;

    private void Awake() {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable() {
        if (playerControls == null) {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

            playerControls.PlayerActions.B.performed += i => b_Input = true;
            playerControls.PlayerActions.B.canceled += i => b_Input = false;

            playerControls.PlayerActions.Interact.performed += (i => {
                interactInput = i.ReadValueAsButton();
                EventManager.TriggerEvent("Interact");
            });

            playerControls.PlayerActions.Drop.performed += (i => {
                dropInput = i.ReadValueAsButton();
                EventManager.TriggerEvent("Drop");
            });

            playerControls.PlayerActions.ShowInfo.performed += (i => {
                showInfoInput = i.ReadValueAsButton();
                EventManager.TriggerEvent("ShowInfo");
            });
        }

        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    public void HandleAllInputs(bool notPaused) {
        if (!notPaused)
            movementInput = Vector2.zero;
        HandleMovementInput();
        HandleSprintingInput();
    }

    private void HandleMovementInput() {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting);
    }
    private void HandleSprintingInput() {
        //if (b_Input && moveAmount > 0.5f) {
        //    playerLocomotion.isSprinting = true;
        //} else {
        //    playerLocomotion.isSprinting = false;
        //}
    }
}
