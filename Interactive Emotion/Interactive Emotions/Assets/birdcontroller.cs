using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdcontroller : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float liftForce = 100.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * liftForce);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * liftForce);
        }
    }
}