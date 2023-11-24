using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MakerFairActionMono : MonoBehaviour
{

    public MakerFairAction m_action;

    public UnityEvent m_setTelloMode;
    public UnityEvent m_setAcroMode;
    public UnityEvent m_switchGameMode;


    void Start()
    {
        m_action = new MakerFairAction();
        m_action.Enable();
        m_action.MakerFair.Enable();
        m_action.MakerFair.SwitchGameMode.performed += (k) => { m_switchGameMode.Invoke(); };
        m_action.MakerFair.SetDroneFPV.performed += (k) => { m_setAcroMode.Invoke(); };
        m_action.MakerFair.SetDroneTello.performed += (k) => { m_setTelloMode.Invoke(); };
    }

   
}
