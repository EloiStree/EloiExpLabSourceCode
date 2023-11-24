using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI3D_SetDigitSceneTimerEvent : MonoBehaviour
{
    public SecondEvent m_levelTimeAsSeconds;
    public SecondEvent m_gameTimeAsSeconds;
    [System.Serializable]
    public class SecondEvent :UnityEvent<int>{ }
  
    void Update()
    {
        m_levelTimeAsSeconds.Invoke((int)Time.timeSinceLevelLoad);
        m_gameTimeAsSeconds.Invoke((int)Time.time);
    }
}
