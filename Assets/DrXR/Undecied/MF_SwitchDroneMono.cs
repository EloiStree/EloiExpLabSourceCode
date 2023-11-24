using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MF_SwitchDroneMono : MonoBehaviour
{
    public Eloi.PrimitiveUnityEventExtra_Bool m_setAsAcroDrone;
    public Eloi.PrimitiveUnityEventExtra_Bool m_setAsTelloDrone;


    [ContextMenu("RequestAcroDrone")]
    public void RequestAcroDrone()
    {
        m_setAsAcroDrone.Invoke(true);
        m_setAsTelloDrone.Invoke(false);
    }
    [ContextMenu("RequestTelloDrone")]
    public void RequestTelloDrone()
    {
        m_setAsAcroDrone.Invoke(false);
        m_setAsTelloDrone.Invoke(true);
    }
}
