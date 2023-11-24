using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultNamedBoolean : INamedBooleanSettable
{
    [SerializeField] string m_nameId;
    [SerializeField] bool m_value;
    public string GetName()
    {
        return m_nameId;
    }
    public void GetName(out string name)
    {
        name = m_nameId;
    }
    public void GetNameRefInContainer(ref string name)
    {
        name = m_nameId;
    }
    public bool GetValue()
    {
        return m_value;
    }
    public void GetValue(out bool value)
    {
        value = m_value;
    }
    public void GetValueRefInConainer(ref bool value)
    {
        value = m_value;
    }
    public void SetName(in string name)
    {
        m_nameId = name;
    }
    public void SetValue(in bool value)
    {
        m_value = value;
    }
}
