using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    public LayerMask groundLayer;

    Vector3 moveDirection;
    Transform cameraObject;
    Rigidbody playerRigidbody;

    public bool isSprinting;

    public float walkingSpeed = 1.5f;
    public float runningSpeed = 5;
    public float sprintingSpeed = 7;
    public float rotationSpeed = 15;

    public float rayCastHeightOffset = 0.5f;

    private void Awake() {
        inputManager = GetComponent<InputManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement(bool notPaused) {
        HandleMovement(notPaused);
        HandleRotation(notPaused);
        HandleStairsSlopes();
    }

    private void HandleMovement(bool notPaused) {
        moveDirection = cameraObject.forward * inputManager.verticalInput;
        moveDirection += cameraObject.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        if (isSprinting)
            moveDirection *= sprintingSpeed;
        else {
            if (inputManager.moveAmount >= 0.5f)
                moveDirection *= runningSpeed;
            else
                moveDirection *= walkingSpeed;
        }

        

        Vector3 movementVelocity = moveDirection;
        if (!notPaused)
            movementVelocity = Vector3.zero;
        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation(bool notPaused) {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * inputManager.verticalInput;
        targetDirection += cameraObject.right * inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (notPaused)
            transform.rotation = playerRotation;
    }

    private void HandleStairsSlopes() {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        Vector3 targetPosition = transform.position;
        rayCastOrigin.y += rayCastHeightOffset;

        if (Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, groundLayer)) {
            Vector3 rayCastHitPoint = hit.point;
            targetPosition.y = rayCastHitPoint.y;
        }

        if (inputManager.moveAmount > 0) {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
        } else {
            transform.position = targetPosition;
        }
    }
}
