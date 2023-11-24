using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnyInteractionToPercentActionWithGlobalTimeMono: InterActionToPercentActionWithGlobalTimeMono<InteractableObjectMono> { 

}
public class InterActionToPercentActionWithGlobalTimeMono<T> : MonoBehaviour where T: InteractableObjectMono
{
    public T m_interactionObserved;
    public TimePercentToAction[] m_timeToAction;
    [System.Serializable]
    public class TimePercentToAction
    {

        public float m_fullPercentTimeSecond;
        public PercentChangeEvent m_onPercentChanged;
        public UnityEvent m_triggerOnReach;
        public float m_currentPercent;


    }

    [System.Serializable]
    public class PercentChangeEvent : UnityEvent<float> { }


    public float m_previousTime;
    public float m_currentTime;
    void Update()
    {
        m_previousTime = m_currentTime;
        m_currentTime = m_interactionObserved.m_interactionGlobalTimeCountSeconds;

        if (m_previousTime != m_currentTime) { 
            for (int i = 0; i < m_timeToAction.Length; i++)
            {
                    if (m_currentTime <= m_timeToAction[i].m_fullPercentTimeSecond)
                    {
                        m_timeToAction[i].m_currentPercent = m_currentTime / m_timeToAction[i].m_fullPercentTimeSecond;
                        m_timeToAction[i].m_onPercentChanged.Invoke(m_timeToAction[i].m_currentPercent);
                    }
                    else if (m_currentTime > m_timeToAction[i].m_fullPercentTimeSecond)
                    {
                        if (m_timeToAction[i].m_currentPercent < 1f)
                            m_timeToAction[i].m_currentPercent = 1f;
                        m_timeToAction[i].m_onPercentChanged.Invoke(m_timeToAction[i].m_currentPercent);
                    }
                    else if (m_currentTime <=0)
                    {
                        m_timeToAction[i].m_currentPercent = m_currentTime / m_timeToAction[i].m_fullPercentTimeSecond;
                        m_timeToAction[i].m_onPercentChanged.Invoke(m_timeToAction[i].m_currentPercent);
                    }

                    if (m_timeToAction[i].m_fullPercentTimeSecond <= m_currentTime && m_previousTime < m_timeToAction[i].m_fullPercentTimeSecond)
                    {
                        m_timeToAction[i].m_triggerOnReach.Invoke();
                    }
            }
        }
    }
    protected virtual void Reset()
    {
        m_interactionObserved = GetComponent<T>();
    }
}
