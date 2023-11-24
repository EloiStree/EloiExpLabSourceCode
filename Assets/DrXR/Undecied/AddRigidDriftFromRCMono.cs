using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRigidDriftFromRCMono : MonoBehaviour
{
    public Transform m_trackedPoint;
    public Rigidbody m_rigidBodyToAffect;
    public Vector3 m_lastPosition;

    public float m_forcePerDistance = 0.1f;
    public ForceMode m_forceMode = ForceMode.Acceleration;


    void Update()
    {
        Vector3 dir = m_trackedPoint.position - m_lastPosition;
        dir.y = 0;
        m_lastPosition = m_trackedPoint.position;
        m_rigidBodyToAffect.AddForce( dir*m_forcePerDistance, m_forceMode);


    }
    private void Reset()
    {
        m_trackedPoint = transform;
        m_rigidBodyToAffect = GetComponentInParent<Rigidbody>();
        if(m_rigidBodyToAffect ==null)
            m_rigidBodyToAffect = GetComponentInChildren<Rigidbody>();
    }
}
