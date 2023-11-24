using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToDoOnInteractionMono : MonoBehaviour
{

    public UnityEvent m_actionToTrigger;
    public Action m_methodeToCall;


    public void TriggerAction() { 
        m_actionToTrigger.Invoke();
        if (m_methodeToCall != null)
            m_methodeToCall.Invoke();
    }
    public void AddAction(in Action action) { m_methodeToCall += action.Invoke; }
    public void RemoveAction(in Action action) { m_methodeToCall -= action.Invoke; }
}
