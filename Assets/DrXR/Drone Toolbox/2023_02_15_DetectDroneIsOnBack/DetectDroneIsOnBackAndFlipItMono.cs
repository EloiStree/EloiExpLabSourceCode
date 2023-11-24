using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectDroneIsOnBackAndFlipItMono : MonoBehaviour
{
    public Transform m_droneUpDirection;
    public Transform m_droneCenterPosition;
    public Transform m_worldUpDirection;

    public float m_movingDeathzone=0.1f;
    public float m_inactivityBeforeFlip = 2;
    public DefaultBooleanChangeListener m_droneOnHisBack;
    public VisibleComputeValue m_debugValue ;

    [System.Serializable]
    public class VisibleComputeValue {
        public float m_angleBetweenDirection;
        public Vector3 m_currentPosition;
        public Vector3 m_lastPosition;
        public float m_distanceBetweenPositions;
        public Eloi.SerializableDateTime m_timeSinceLastMoveDetected;
        public bool m_isDroneOnItBack;
    }
    void Update()
    {
        CheckForNeedOfFlip();
    }

    private void CheckForNeedOfFlip()
    {
        m_debugValue.m_isDroneOnItBack = false;
        Vector3 worldUp = Vector3.up;
        if (m_worldUpDirection != null)
            worldUp = m_worldUpDirection.forward;
        m_debugValue.m_angleBetweenDirection = Vector3.Angle(m_droneUpDirection.forward, worldUp);
        m_debugValue.m_currentPosition = m_droneCenterPosition.position;
        m_debugValue.m_distanceBetweenPositions = Vector3.Distance(m_debugValue.m_currentPosition, m_debugValue.m_lastPosition);
        if (m_debugValue.m_distanceBetweenPositions > m_movingDeathzone) {
            m_debugValue.m_timeSinceLastMoveDetected.SetWithDate( DateTime.Now);
        }
        m_droneOnHisBack.SetBoolean(m_debugValue.m_angleBetweenDirection > 90f && (DateTime.Now - m_debugValue.m_timeSinceLastMoveDetected.GetAsDate()).TotalSeconds > m_inactivityBeforeFlip);
    }
}
