using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveDroneToLocalPositionMono : MonoBehaviour
{
    public Transform m_whatToMove;
    public Vector3 m_localPosition;
    public Quaternion m_localRotation;


    public void SetPosition(Vector3 position) {
        m_whatToMove.localPosition = position;
    }

    public void SetRotation(Quaternion rotation) {
        m_whatToMove.localRotation = rotation;
    }



}
