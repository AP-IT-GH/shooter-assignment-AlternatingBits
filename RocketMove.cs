using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Aeroplane;

public class RocketMove : MonoBehaviour
{
    //private Rigidbody2D rb;
    private Rigidbody rb;

    public float maxVelocity = 3;
    public float maxAngularVelocity = 3;
    public float rotationSpeed = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = maxAngularVelocity;

    }

    private void Update()
    {
        float xAxis = 0-CrossPlatformInputManager.GetAxis("Horizontal");
        bool throttleEnabled = CrossPlatformInputManager.GetButton("Jump");
        float yAxis = (throttleEnabled) ? 3 : 0;
        
        ThrustForward(yAxis);
        Rotate(xAxis * rotationSpeed);
        ClampVelocity();
        
    }

    private void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;
        
        rb.AddForce(force, ForceMode.Force);
    }

    private void Rotate(float amount)
    {
        Vector3 force = transform.forward * amount;
        
        rb.AddTorque(force, ForceMode.Force);
    }
}
