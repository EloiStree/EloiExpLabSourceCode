using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class DefaultFlipDroneUpMono : MonoBehaviour
{

    public float m_translateUpWhenFlip = 0.05f;
    public Transform m_whatToMoveToFlip;
    public Transform m_worldDirection;

    public void Flip() { 
    
       Vector3 worldUp = m_worldDirection==null? Vector3.up : m_worldDirection.position;
        m_whatToMoveToFlip.up = m_worldDirection.up;
        m_whatToMoveToFlip.Translate(worldUp * m_translateUpWhenFlip);
    }
}
