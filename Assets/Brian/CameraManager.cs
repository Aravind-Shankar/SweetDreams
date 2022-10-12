using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform targetTransform; // the object the camera will follow
    public Transform cameraPivot;     // the object the camera uses to pivot (look up and down)
    public Transform cameraTransform; // the transform of the actual camera object in the scene
    public LayerMask collisionLayers; // the layers we want our camera to collide with
    private float defaultCameraDistanceFromPlayer;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 cameraVectorPosition;

    public float cameraCollisionOffset = 0.2f; // how much the camera will jump off of objects it's colliding with
    public float minimumCollisionOffset = 1f;
    public float cameraCollisionRadius = 0.2f;
    public float cameraFollowSpeed = 0.2f;
    public float cameraHorizontalSpeed = 2;
    public float cameraVerticalSpeed = 2;

    public float horizontalAngle;
    public float verticalAngle;
    public float minimumVerticalAngle = -35;
    public float maximumVerticalAngle = 35;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerManager>().transform;
        cameraTransform = Camera.main.transform;
        defaultCameraDistanceFromPlayer = cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {

        Vector3 rotation;
        Quaternion targetRotation;

        horizontalAngle = horizontalAngle + (inputManager.cameraInputHorizontal * cameraHorizontalSpeed);
        verticalAngle = verticalAngle - (inputManager.cameraInputVertical * cameraVerticalSpeed);
        verticalAngle = Mathf.Clamp(verticalAngle, minimumVerticalAngle, maximumVerticalAngle);

        rotation = Vector3.zero;
        rotation.y = horizontalAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = verticalAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisions()
    {
        float targetCameraDistanceFromPlayer = defaultCameraDistanceFromPlayer;

        RaycastHit hit;
        Vector3 directionTowardCamera = cameraTransform.position - cameraPivot.position;
        directionTowardCamera.Normalize();

        if (Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, directionTowardCamera, out hit, Mathf.Abs(targetCameraDistanceFromPlayer), collisionLayers)) 
        {
            float distanceToCollision = Vector3.Distance(cameraPivot.position, hit.point);
            Debug.Log(distanceToCollision);
            Debug.Log(hit.collider);
            //Debug.DrawRay(cameraPivot.position, hit.point);

            //Debug.Log(targetCameraDistanceFromPlayer);
            targetCameraDistanceFromPlayer = 0 - (distanceToCollision - cameraCollisionOffset);
            //Debug.Log(targetCameraDistanceFromPlayer);
            //Debug.Log("-===-");
            //targetCameraDistanceFromPlayer = Mathf.Clamp(0 - (distanceToCollision - cameraCollisionOffset), -minimumCollisionOffset, defaultCameraDistanceFromPlayer);
        }

        //if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
        //{
        //    Debug.Log("under minimum, adjusting..");
        //    targetPosition = targetPosition - minimumCollisionOffset;
        //}

        //Debug.Log(targetPosition + " " + cameraVectorPosition);

        // cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        //cameraTransform.localPosition = cameraVectorPosition;
        cameraVectorPosition.z = targetCameraDistanceFromPlayer;
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
