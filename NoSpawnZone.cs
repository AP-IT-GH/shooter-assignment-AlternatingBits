using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpawnZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Coin")
            other.gameObject.GetComponent<CoinBehaviour>().SetNewPos();
    }
}
