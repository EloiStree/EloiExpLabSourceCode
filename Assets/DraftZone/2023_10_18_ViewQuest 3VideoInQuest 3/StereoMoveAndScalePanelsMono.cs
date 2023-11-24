using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StereoMoveAndScalePanelsMono : MonoBehaviour
{

    [Range(0.03f, 5f)]
    public float m_depth_z = 0.5f;
    [Range(0, 0.5f)]
    public float m_eyeDistance_x = 0.5f;
    [Range(0,1.8f)]
    public float m_localPanelScale = 0.5f;

    public Transform m_leftEye;
    public Transform m_rightEye;

    void Update()
    {

        if (m_leftEye!=null && m_rightEye!=null) {
            Vector3 localleft= Vector3.zero, localRight = Vector3.zero;
            localleft.z = m_depth_z;
            localRight.z = m_depth_z;
            localleft.x = -m_eyeDistance_x;
            localRight.x= m_eyeDistance_x;
            m_leftEye.localPosition = localleft;
            m_rightEye.localPosition = localRight;
            m_leftEye.localScale = Vector3.one * m_localPanelScale;
            m_rightEye.localScale = Vector3.one * m_localPanelScale;
        }

    }
}
