using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DroneRCToDroneCustom : MonoBehaviour
{
    public DroneMovement m_droneMovement;
    public float m_axisAmplificationUp = 0.5f;
    public float m_axisAmplificationHorizontal = 0.1f;
    public float m_axisAmplificationHorizontalRotation = 0.7f;
    public bool m_inverseRaw=true;

    public void SetLeftToRightRange(float rangePercent)
    {
        m_droneMovement.CustomFeed_roll = m_axisAmplificationHorizontal * rangePercent ;

    }
    public void SetLeftToRightRotationRange(float rangePercent)
    {
        m_droneMovement.CustomFeed_yaw = m_axisAmplificationHorizontalRotation * rangePercent * (m_inverseRaw?-1f:1f);
    }
    public void SetDownUpRange(float rangePercent)
    {

        m_droneMovement.CustomFeed_throttle = m_axisAmplificationUp * rangePercent;

    }
    public void SetBackFrontRange(float rangePercent)
    {
        m_droneMovement.CustomFeed_pitch = m_axisAmplificationHorizontal * rangePercent;
    }
}
    
