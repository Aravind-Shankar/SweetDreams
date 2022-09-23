using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float moveUp = 0.0f;
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0.0f)
            moveUp = 40.0f;

        Vector3 movement = new Vector3(moveHorizontal, moveUp, moveVertical);

        rb.AddForce(movement * speed);
    }
}
