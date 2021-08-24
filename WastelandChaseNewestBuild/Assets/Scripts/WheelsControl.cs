using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsControl : MonoBehaviour
{
    Vector3 localAngle;
    public float MaxSteerAngle = 30f;
    private float steerAngle = 0f;

    void LateUpdate()
    {
        localAngle = transform.localEulerAngles;
        localAngle.z = steerAngle;
        transform.localEulerAngles = localAngle;
    }

    public void UpdateWheelAngle(float WheelAngle)
    {
        steerAngle = -WheelAngle * MaxSteerAngle;
    }

}
