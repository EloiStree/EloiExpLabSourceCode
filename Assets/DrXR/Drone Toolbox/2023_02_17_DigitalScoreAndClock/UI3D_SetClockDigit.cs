using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI3D_SetClockDigit : MonoBehaviour
{
    public int m_value;
    public BoolEvent m_up;
    public BoolEvent m_center;
    public BoolEvent m_down;
    public BoolEvent m_downLeft;
    public BoolEvent m_upLeft;
    public BoolEvent m_downRight;
    public BoolEvent m_upRight;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void OnValidate()
    {
        SetWithInt(m_value);
    }

    public void SetWithChar(char digit)
    {
        
        switch (digit)
        {
            case '0': FullEnable(); m_center.Invoke(false); break;
            case '1': FullDisable(); m_downRight.Invoke(true); m_upRight.Invoke(true); break;
            case '2': FullEnable(); m_upLeft.Invoke(false); m_downRight.Invoke(false); break;
            case '3': FullEnable(); m_upLeft.Invoke(false); m_downLeft.Invoke(false); break;
            case '4': FullEnable(); m_up.Invoke(false); m_downLeft.Invoke(false); m_down.Invoke(false); break;
            case '5': FullEnable(); m_upRight.Invoke(false); m_downLeft.Invoke(false); break;
            case '6': FullEnable(); m_upRight.Invoke(false);  break;
            case '7': FullEnable(); m_downLeft.Invoke(false); m_upLeft.Invoke(false); m_down.Invoke(false); m_center.Invoke(false); break;
            case '8': FullEnable(); break;
            case '9': FullEnable(); m_downLeft.Invoke(false); break;
            default:
                break;
        }
    }



    public void FullEnable()
    {
         m_up.Invoke(true);
         m_center.Invoke(true);  
         m_down.Invoke(true);
         m_downLeft.Invoke(true);
         m_upLeft.Invoke(true);
         m_downRight.Invoke(true);
         m_upRight.Invoke(true);

    }

    public void FullDisable()
    {
        m_up.Invoke(false);
        m_center.Invoke(false);
        m_down.Invoke(false);
        m_downLeft.Invoke(false);
        m_upLeft.Invoke(false);
        m_downRight.Invoke(false);
        m_upRight.Invoke(false);
    }

    public void SetWithInt(int digit)
    {
        int d = digit % 10;
        string t = d.ToString();
        SetWithChar(t[0]);
    }


}
