using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowProgressifSetRandomAtAwake : MonoBehaviour
{

    public GrowProgressif m_toAffect;
    public Vector3 m_minMinRandom = Vector3.one * 0.1f, m_minMaxRandom = Vector3.one * 3;
    public Vector3 m_maxMinRandom = Vector3.one * 5, m_maxMaxRandom = Vector3.one * 10;
    public float m_minGrowTime=0.1f;
    public float m_maxGrowTime=0.5f;

    

    public void ApplyGrowingInformation() {
        Eloi.E_UnityRandomUtility.GetRandomN2M(0, 1f, out float percent);
        m_toAffect.m_minValue = Vector3.Lerp(m_minMinRandom, m_minMaxRandom, percent);
        Eloi.E_UnityRandomUtility.GetRandomN2M(0, 1f, out percent);
        m_toAffect.m_maxValue = Vector3.Lerp(m_maxMinRandom, m_maxMaxRandom, percent);
        Eloi.E_UnityRandomUtility.GetRandomN2M(m_minGrowTime, m_maxGrowTime, out float timeToGrow);
        m_toAffect.m_timeToGrowMax = timeToGrow;
    }

    private void Reset()
    {
        m_toAffect = GetComponent<GrowProgressif>();

    }
}
