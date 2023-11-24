using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugINamedBooleanMono : MonoBehaviour
{

    public StructNamedBoolean m_lastReceived;
    public void PushIn(INamedBooleanGet namedBoolean)
    {
        m_lastReceived.SetName(namedBoolean.GetName());
        m_lastReceived.SetValue(namedBoolean.GetValue());
    }
}
