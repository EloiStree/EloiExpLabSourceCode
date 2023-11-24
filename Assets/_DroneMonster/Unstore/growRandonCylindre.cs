using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growRandonCylindre : MonoBehaviour
{

    public GrowProgressif toAffect;

    public Vector3 m_minMinRandom = Vector3.one * 0.1f, m_minMaxRandom = Vector3.one * 3;
    public Vector3 m_maxMinRandom = Vector3.one * 5, m_maxMaxRandom = Vector3.one * 10;

    // Start is called before the first frame update
    void Awake()
    {
        Eloi.E_UnityRandomUtility.GetRandomN2M(0, 1f, out float percent);
        toAffect.m_minValue = Vector3.Lerp(m_minMinRandom, m_minMaxRandom, percent);

        Eloi.E_UnityRandomUtility.GetRandomN2M(0, 1f, out percent);
        toAffect.m_maxValue = Vector3.Lerp(m_maxMinRandom, m_maxMaxRandom, percent);

    }

    private void Reset()
    {
        toAffect = GetComponent<GrowProgressif>();


    }
}

