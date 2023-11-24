using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3D_SetDigitClockHHMM : MonoBehaviour
{
    public UI3D_SetClockNumber m_leftPartHH;
    public UI3D_SetClockNumber m_rightPartMM;


    public void OnValidate()
    {
        SetWithCurrentDate();
    }

    private void SetToDate(DateTime now)
    {
        int hour = now.Hour;
        int minute = now.Minute;
        m_leftPartHH.SetWithNumber(hour);
        m_rightPartMM.SetWithNumber(minute);
    }
    [ContextMenu("SetWithCurrentDate")]
    public void SetWithCurrentDate() {

        SetToDate(DateTime.Now);
    }
}
