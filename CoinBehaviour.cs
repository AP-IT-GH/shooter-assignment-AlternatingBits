using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinBehaviour : MonoBehaviour
{
    public float maxSquarSpawnRadius;
    public Manager manager;

    private float defaultZ;
    // Start is called before the first frame update
    void Start()
    {
        defaultZ = this.transform.position.z;
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
         // if((Time.time) % 1 < 0.1)
         //     SetNewPos();
    }

    private void OnTriggerEnter(Collider other)
    {
        SetNewPos();
    }

    public void SetNewPos()
    {
        var randX = (Random.value * maxSquarSpawnRadius * 2.0) - maxSquarSpawnRadius;
        var randY = (Random.value * maxSquarSpawnRadius * 2.0) - maxSquarSpawnRadius;

        var newPos = new Vector3((float)randX, (float)randY, defaultZ);
        var checkPos = new Vector3(newPos.x, newPos.y - 4.5f, newPos.z);
        
        LayerMask onlyWorld = ~(1 << 9);
        LayerMask onlyCoin = ~(1 << 6);

        if (!Physics.CheckSphere(newPos, 15f, onlyCoin) && Physics.CheckSphere(checkPos, 0.1f, onlyWorld)
                && !Physics.CheckSphere(newPos, 0.1f, onlyWorld))
        {
            this.transform.position = newPos;
            manager.AddScore();
        }
        else
        {
            SetNewPos();   
        }
    }
}