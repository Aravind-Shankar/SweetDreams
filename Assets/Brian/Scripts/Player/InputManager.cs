using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerControls playerControls;
    AnimatorManager animatorManager;

    private Vector2 movementInput;
    private Vector2 cameraInput;
    private bool interactInput;

    public float cameraInputVertical;
    public float cameraInputHorizontal;

    private float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool interactInputPressed;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += (i => movementInput = i.ReadValue<Vector2>());
            playerControls.PlayerMovement.Camera.performed += (i => cameraInput = i.ReadValue<Vector2>());

            // this callback is called only once upon every key press of the Interact action
            // maybe do something here that either has PlayerManager listening to this callback, or having this callback call the playermanager function for interaction
            playerControls.PlayerInteraction.Interact.performed += (i => {
                interactInput = i.ReadValueAsButton();
                EventManager.TriggerEvent("Interact");
                });
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputVertical = cameraInput.y;
        cameraInputHorizontal = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
}
