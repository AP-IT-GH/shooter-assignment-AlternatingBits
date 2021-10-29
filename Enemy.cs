using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum AxisSwitch
    {
        X,
        Z,
        Y
    }

    public float radiusMovement = 5.0f;
    public float frequencyMovement = 1.0f;
    public AxisSwitch AxisSwitchState;

    private Vector3 initialPos;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, 0, 0);
        switch (AxisSwitchState)
        {
            case AxisSwitch.X:
                offset.x = CalcOffset();
                break;
            case AxisSwitch.Z:
                offset.z = CalcOffset();
                break;
            case AxisSwitch.Y:
                offset.y = CalcOffset();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        transform.position = initialPos + offset;
    }

    float CalcOffset()
    {
        return Mathf.Sin(Time.time * frequencyMovement) * radiusMovement;
    }
}
