using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrowProgressif : MonoBehaviour
{

    public float m_timeToGrowMax = 2;
   
    public Vector3 m_minValue;
    public Vector3 m_maxValue= Vector2.one;

    public Transform m_whatToGrow;

    public float m_timePasted;

    public UnityEvent m_onGrown;


    public void SetSize(float percent) 
    {

        m_whatToGrow.localScale =  Vector3.Lerp(m_minValue, m_maxValue, percent);

        //Vector3 temporaire = m_whatToGrow.localScale;
        //temporaire.z  = hauteurZ;

        //m_whatToGrow.localScale = temporaire;
    }

    void Update()
    {

        m_timePasted += Time.deltaTime;
        //Eloi.E_UnityRandomUtility.GetRandomN2M(1, 6, out float monRandom);

        //m_maxValue = m_maxValue * monRandom;

        float percent = m_timePasted/m_timeToGrowMax;
        SetSize(percent);
        if (percent > 1f) {
            m_onGrown.Invoke();
        }
    }
    private void Reset()
    {
        m_whatToGrow = transform;
    }
}
