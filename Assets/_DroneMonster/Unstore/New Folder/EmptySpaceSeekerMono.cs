using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpaceSeekerMono : MonoBehaviour
{
    public Transform m_centerOfCheck;
    public float m_coverZoneRadius = 1.5f;
    public float m_uncoverInnerRadius = 0.3f;
    public float m_scanZoneRadius = 0.1f;
    public LayerMask m_allowCollision;
    public int m_checkCount=20;
    public List<Vector3> m_validePosition = new List<Vector3>();

   
    public void DoCheck() {
        Vector3 position = m_centerOfCheck.position ;
        m_validePosition.Clear();
        for (int i = 0; i < m_checkCount; i++)
        {
            E_UnityRandomUtility.GetRandomQuaternion(out Quaternion q);
            E_UnityRandomUtility.GetRandomN2M(m_uncoverInnerRadius, m_coverZoneRadius, out float distance);
            Vector3 localcheck = position + (q * m_centerOfCheck.forward) * distance;
            Collider [] collisions = Physics.OverlapSphere(localcheck, m_scanZoneRadius, m_allowCollision);
            if (collisions.Length == 0)
                m_validePosition.Add(localcheck);
            Eloi.E_DrawingUtility.DrawAxe(localcheck, q ,E_DrawingUtility.AxisType.Up, collisions.Length == 0?Color.green:Color.red, 0.1f, 0.1f);
        }
    }

    public bool HasValidePoint() { return m_validePosition.Count > 0; }
    public void GetClosePointOf(Vector3 destination, out Vector3 bestTarget) {

        bestTarget = destination;

        float closeDistance = float.MaxValue;
        for (int i = 0; i < m_validePosition.Count; i++)
        {
            float distance = (destination - m_validePosition[i]).magnitude;
            if (distance < closeDistance) {
                closeDistance = distance;
                bestTarget = m_validePosition[i];
            }
        }

        
    }

    public bool m_useUpdate;
    void Update()
    {
        if (m_useUpdate)
        DoCheck();
        
    }

    public void GetRandomValidePoint(out Vector3 point)
    {
        Eloi.E_UnityRandomUtility.GetRandomOf(out point , m_validePosition);
    }

    public void GetCenterOfValidePoint(out Vector3 resultPoint)
    {
        resultPoint = new Vector3();
        var totalX = 0f;
        var totalY = 0f;
        foreach (var point in m_validePosition)
        {
            totalX += point.x;
            totalY += point.y;
        }
        resultPoint.x = totalX / m_validePosition.Count;
        resultPoint.y= totalY / m_validePosition.Count;
    }
}
