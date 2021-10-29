using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RocketController : MonoBehaviour
{
    
    public float forwardSpeed = 25f, strafeSpeed = 7.5f, hoverSpeed = 5f;

    private float activeForwardSpeed, activeStrafeSpeed, acticeHoverSpeed;

    private float forwardAccerelation = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;

    private Vector2 lookInput, screenCenter, lookDistance;

    private float rollInput;

    public float rollSpeed = 90f, rollAcceleration = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        lookInput.x = CrossPlatformInputManager.GetAxis("Horizontal");
        lookInput.y = -CrossPlatformInputManager.GetAxis("Vertical");

        lookDistance = Vector2.ClampMagnitude(lookInput, 1.0f);

        rollInput = Mathf.Lerp(rollInput, -CrossPlatformInputManager.GetAxisRaw("Roll"),
            rollAcceleration * Time.deltaTime);
        
        transform.Rotate(-lookDistance.y * lookRateSpeed * Time.deltaTime, lookDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed,
            CrossPlatformInputManager.GetAxisRaw("Speed") * forwardSpeed, forwardAccerelation * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed,
            CrossPlatformInputManager.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        acticeHoverSpeed = Mathf.Lerp(acticeHoverSpeed, CrossPlatformInputManager.GetAxisRaw("Hover") * hoverSpeed,
            hoverAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) +
                              (transform.up * acticeHoverSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this);
            GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.GameOver();
        }
    }
}
