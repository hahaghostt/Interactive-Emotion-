using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingcontroller : MonoBehaviour
{

    public float throttleIncrement = 0.1f;
    public float maxThrust = 200f;
    public float responsiveness = 10f;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw; 

    private float responseModifier
    {
        get {
            return (rb.mass / 10f) * responsiveness; 
        }

    }

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f); 
    }

    private void Update()
    {
        HandleInputs(); 
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * roll * responseModifier);
    }
}
