using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI3D_SetDigitCountDownMMSS : MonoBehaviour
{
    public float m_timeLeft=3;

    public UnityEvent m_onEndOfCountDown;
    public Eloi.PrimitiveUnityEvent_Float m_onTimeChanged;

    void Update()
    {
        if (m_timeLeft > 0f) {

            m_timeLeft -= Time.deltaTime;
            if (m_timeLeft <= 0f)
            {
                m_timeLeft = 0;
                m_onTimeChanged.Invoke(0);
                m_onEndOfCountDown.Invoke();
            }
            else {
                m_onTimeChanged.Invoke(m_timeLeft);
            } 
        }
    }
}
