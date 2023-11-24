using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMirrorVRCameraMono : MonoBehaviour
{
    public Camera m_toApplayOn;
    public Camera m_vrToMirror;
    
    void LateUpdate()
    {
        m_toApplayOn.fieldOfView = m_vrToMirror.fieldOfView;
        m_toApplayOn.transform.position = m_vrToMirror.transform.position;
        m_toApplayOn.transform.rotation = m_vrToMirror.transform.rotation;
    }
}
