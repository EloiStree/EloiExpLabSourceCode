using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractionGuidRegisterStatic : MonoBehaviour
{

    static Dictionary<string, object> m_interactionSource = new Dictionary<string, object>();

    public static void GetSourceKey(out string[] guidOfSources) { guidOfSources = m_interactionSource.Keys.ToArray(); }
    public static void GetSource(out object[] sources) { sources = m_interactionSource.Values.ToArray(); }
    public static void GetSourceAs<T>(out T[] sources) { sources = m_interactionSource.Values.Where(k => k is T).Select(k=>(T)k).ToArray(); }

    public static void AddInteractionSource(string guid, object source)
    {
        if (!m_interactionSource.ContainsKey(guid))
            m_interactionSource.Add(guid, source);
    }
    public static void RemoveInteractionSource(string guid)
    {
        if (m_interactionSource.ContainsKey(guid))
            m_interactionSource.Remove(guid);
    }

    
}
