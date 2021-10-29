using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundBehaviour : MonoBehaviour
{
    public Transform target;

    public int speed;

    public int angle;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = this.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Quaternion.AngleAxis(angle, Vector3.forward) * target.transform.up, speed * Time.deltaTime);
    }
}
