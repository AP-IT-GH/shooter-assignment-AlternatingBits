using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    
    public GameObject ManagerGameObject;

    private GameManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = ManagerGameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
        if(other.name == "RocketFront")
            Manager.DidARound();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
