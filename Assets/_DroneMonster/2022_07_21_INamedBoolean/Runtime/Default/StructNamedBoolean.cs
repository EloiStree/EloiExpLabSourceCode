using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StructNamedBoolean : INamedBooleanSettable
{
    [SerializeField] string m_nameId;
    [SerializeField] bool m_value;

    public StructNamedBoolean()
    {
        m_nameId = "";
        m_value = false;
    }

    public StructNamedBoolean(string nameId, bool value)
    {
        m_nameId = nameId;
        m_value = value;
    }

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
        value = m_value ;
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
