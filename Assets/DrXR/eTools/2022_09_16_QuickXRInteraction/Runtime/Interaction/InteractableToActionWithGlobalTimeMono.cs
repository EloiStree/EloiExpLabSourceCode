using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AnyInteractableToActionWithGlobalTimeMono : InteractableToActionWithGlobalTimeMono<InteractableObjectMono>
{

}
public class InteractableToActionWithGlobalTimeMono<T> : MonoBehaviour where T : InteractableObjectMono
{
    public T m_interactionObserved;
    public TimeToAction[] m_interactionTimeToAction;

    [System.Serializable]
    public class TimeToAction {
        public float m_triggerTime;
        public UnityEvent m_actionToTrigger;
    }


    public float m_previousTime;
    public float m_currentTime;
    void Update()
    {
        m_previousTime = m_currentTime;
        m_currentTime = m_interactionObserved.m_interactionGlobalTimeCountSeconds;

        for (int i = 0; i < m_interactionTimeToAction.Length; i++)
        {
            if (m_interactionTimeToAction[i].m_triggerTime <= m_currentTime && m_previousTime< m_interactionTimeToAction[i].m_triggerTime) { 
                m_interactionTimeToAction[i].m_actionToTrigger.Invoke();
            }
        }
    }
    public virtual void Reset()
    {
        m_interactionObserved = GetComponent<T>();
    }
}
