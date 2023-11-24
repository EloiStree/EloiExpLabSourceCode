using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateAccessNamedBoolean : INamedBooleanSettable
{
    public delegate bool   D_GetBoolean();
    public delegate string D_GetName();
    public delegate void   D_SetBoolean(in bool value);
    public delegate void   D_SetName(in string name);
    D_GetBoolean      m_getBoolAcces;
    D_GetName         m_getNamedAcces;
    D_SetBoolean      m_setBoolAcces;
    D_SetName         m_setNamedAcces;

    public DelegateAccessNamedBoolean()
    {
    }

    public DelegateAccessNamedBoolean(D_GetBoolean getBoolAcces, D_GetName getNamedAcces)
    {
        m_getBoolAcces = getBoolAcces;
        m_getNamedAcces = getNamedAcces;
    }

    public DelegateAccessNamedBoolean(D_GetBoolean getBoolAcces, D_GetName getNamedAcces, D_SetBoolean setBoolAcces, D_SetName setNamedAcces)
    {
        m_getBoolAcces = getBoolAcces;
        m_getNamedAcces = getNamedAcces;
        m_setBoolAcces = setBoolAcces;
        m_setNamedAcces = setNamedAcces;
    }

    public void SetGetter(in D_GetName name, in D_GetBoolean boolean)
    {
        m_getNamedAcces = name;
        m_getBoolAcces = boolean;
    }
    public void SetSetter(in D_SetName name, in D_SetBoolean boolean)
    {
        m_setNamedAcces = name;
        m_setBoolAcces = boolean;
    }
    public bool IsGetterDefined() { return m_getBoolAcces != null && m_getNamedAcces != null; }
    public bool IsSetterDefined() { return m_setBoolAcces != null && m_setNamedAcces != null; }


    public void GetName(out string name)
    {
        if (m_getNamedAcces != null)
            name = m_getNamedAcces();
        else
            name= "";
    }

    public string GetName()
    {
        if (m_getNamedAcces != null)
            return m_getNamedAcces();
        return "";
    }

    public void GetNameRefInContainer(ref string name)
    {
        if (m_getNamedAcces != null)
            name = m_getNamedAcces();
        else
            name = "";
    }

    public void GetValue(out bool value)
    {
        if (m_getBoolAcces != null)
            value = m_getBoolAcces();
        else
            value = false;
    }

    public bool GetValue()
    {
        if (m_getBoolAcces != null)
            return m_getBoolAcces();
        else
            return false;
    }

    public void GetValueRefInConainer(ref bool value)
    {
        if (m_getBoolAcces != null)
            value = m_getBoolAcces();
        else
            value = false;
    }

    public void SetName(in string name)
    {
        if (m_setNamedAcces != null)
             m_setNamedAcces(name);
    }

    public void SetValue(in bool value)
    {

        if (m_setBoolAcces != null)
            m_setBoolAcces(value);
    }
}
