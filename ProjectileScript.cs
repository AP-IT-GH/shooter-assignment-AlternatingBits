using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private GameObject GameManagerObject;

    private GameManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerObject = GameObject.Find("GameManager");
        Manager = GameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag != "Player")
        {
            if (other.gameObject.tag == "Enemy")
            {
                Manager.AddScore(1);
                other.gameObject.SetActive(false);
            }
            Destroy(gameObject);
        }
    }
}
