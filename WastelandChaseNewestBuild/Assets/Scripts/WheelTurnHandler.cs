using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTurnHandler : MonoBehaviour
{

    [SerializeField] WheelsControl m_LeftWheel;
    [SerializeField] WheelsControl m_RightWheel;

 
    public void SetWheelAngle( float WheelAngle)
    {
        m_LeftWheel.UpdateWheelAngle(WheelAngle);
        m_RightWheel.UpdateWheelAngle(WheelAngle);
    }
}
