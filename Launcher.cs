using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Launcher : MonoBehaviour
{
    public Rigidbody LaunchObject;

    public float projectileForce = 700.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            var projectile = Instantiate(LaunchObject, transform.position, transform.rotation);
            Debug.Log(transform.forward);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce);
        }
    }
}
