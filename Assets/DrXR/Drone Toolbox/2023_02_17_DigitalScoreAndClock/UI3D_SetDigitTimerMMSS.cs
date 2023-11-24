using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3D_SetDigitTimerMMSS : MonoBehaviour
{
    
    
    public UI3D_SetClockNumber m_leftPartMM;
    public UI3D_SetClockNumber m_rightPartSS;

    public int m_secondsOfTimer;

    public void OnValidate()
    {
        SetWithSeconds(m_secondsOfTimer);
    }

    public void SetWithSeconds(int secondsOfTimer)
    {
        m_secondsOfTimer = secondsOfTimer;
        int s = secondsOfTimer % 60;
        int m = secondsOfTimer / 60;
        m_leftPartMM.SetWithNumber(m);
        m_rightPartSS.SetWithNumber(s);
    }
    public void SetWithSeconds(float secondsOfTimer)
    {
        SetWithSeconds((int)secondsOfTimer);
    }
}
