using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundDisplayZoneMono : MonoBehaviour
{

    public Transform m_toAffectPosition;
    public Transform m_toAffectScale;
    public bool m_moveLeft;
    public bool m_moveRight;
    public bool m_moveForward;
    public bool m_moveBackward;
    public bool m_rotateLeft;
    public bool m_rotateRight;
    public bool m_scaleUp;
    public bool m_scaleDown;
    public float m_moveValueLeft=0.2f;
    public float m_moveValueRight = 0.2f;
    public float m_moveValueForward = 0.2f;
    public float m_moveValueBackward = 0.2f;
    public float m_rotateValueLeft = 30;
    public float m_rotateValueRight = 30;
    public float m_scaleFactor = 0.1f;

    public void MoveLeft(bool isOn) { m_moveLeft = isOn; }
    public void MoveRight(bool isOn) { m_moveRight = isOn; }
    public void MoveForward(bool isOn) { m_moveForward = isOn; }
    public void MoveBackward(bool isOn) { m_moveBackward = isOn; }
    public void RotateLeft(bool isOn) { m_rotateLeft = isOn; }
    public void RotateRight(bool isOn) { m_rotateRight = isOn; }
    public void ScaleUp(bool isOn) { m_scaleUp = isOn; }
    public void ScaleDown(bool isOn) { m_scaleDown = isOn; }

    public Vector3 m_rotate;
    public Vector3 m_move;
    public float m_scaleValue;
    void Update()
    {

        float dt = Time.deltaTime;

        m_rotate.y = 0;
        if (m_rotateLeft)
            m_rotate.y = -m_rotateValueLeft;
        if (m_rotateRight)
            m_rotate.y = m_rotateValueLeft;
        if(m_toAffectPosition)
        m_toAffectPosition.Rotate(m_rotate * dt, Space.Self);
        if (m_scaleUp)
            m_scaleValue += m_scaleFactor* dt;
        if (m_scaleDown)
            m_scaleValue -= m_scaleFactor * dt;
        if (m_toAffectScale)
            m_toAffectScale.localScale= Vector3.one*m_scaleValue;

        m_move.z = 0;
        m_move.x = 0;
        if (m_moveLeft)
            m_move.x = -m_moveValueLeft;
        if (m_moveRight)
            m_move.x = m_moveValueRight; 
        if (m_moveForward)
            m_move.z = m_moveValueForward;
        if (m_moveBackward)
            m_move.z = -m_moveValueBackward;
        if (m_toAffectPosition)
            m_toAffectPosition.Translate(m_move * dt, Space.Self);

    }

    private void Reset()
    {
        m_toAffectPosition = transform;
    }
}
