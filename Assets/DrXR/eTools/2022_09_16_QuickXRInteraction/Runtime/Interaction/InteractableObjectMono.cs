using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public interface IInteractableObject
{
    public void SetInteractingSource(string sourceId, string sourceName);
    public void RemoveInteractingSource(string sourceId);
}

public class InteractableObjectMono : MonoBehaviour, IInteractableObject
{

    public float m_interactionGlobalTimeCountSeconds;
    public Dictionary<string, string> m_interactionObject = new Dictionary<string, string>();
    public Dictionary<string, float> m_interacitonObjectTime = new Dictionary<string, float>();
    public int m_interactionCount;
    public bool m_useDebug = true;
    public List<string> m_hasInteractionId = new List<string>();
    public List<string> m_hasInteractionNameDebug = new List<string>();
    public List<string> m_hasInteractionWithTimeDebug = new List<string>();
    public bool m_clearOnEnableAndDisable=true;

    public void OnDisable()
    {
        if (m_clearOnEnableAndDisable)
            Clear();
    }
    public void OnEnable()
    {
        if (m_clearOnEnableAndDisable)
            Clear();
    }
    public void Clear() {
        foreach (var item in m_interactionObject.Keys.ToArray())
        {
            RemoveInteractingSource(item);
        }
    }
    public DefaultOnOffBooleanChangeListener m_isInteracting;
    public void SetInteractingSource(string sourceId, string sourceName)
    {
        if (!m_interactionObject.ContainsKey(sourceId))
        {
            m_interactionObject.Add(sourceId, sourceName);
            m_interacitonObjectTime.Add(sourceId, 0);
        }

    }
    public void RemoveInteractingSource(string sourceId)
    {
        if (m_interactionObject.ContainsKey(sourceId))
        {
            m_interactionObject.Remove(sourceId);
            m_interacitonObjectTime.Remove(sourceId);
        }
    }
    public void Update()
    {
        float deltaTime = Time.deltaTime;
        m_interactionCount = m_interactionObject.Count;
        m_hasInteractionId = m_interactionObject.Keys.ToList();
        if (m_interactionCount > 0)
        {
            m_interactionGlobalTimeCountSeconds += deltaTime;
        }
        else
        {
            m_interactionGlobalTimeCountSeconds = 0;
        }
        if (m_useDebug)
            m_hasInteractionNameDebug = m_interactionObject.Values.ToList();
        if (m_useDebug)
            m_hasInteractionWithTimeDebug.Clear();
        for (int i = 0; i < m_hasInteractionId.Count; i++)
        {
            m_interacitonObjectTime[m_hasInteractionId[i]] += deltaTime;
            if (m_useDebug)
                m_hasInteractionWithTimeDebug.Add(m_interacitonObjectTime[m_hasInteractionId[i]] + " | " + m_hasInteractionId[i]);

        }

        m_isInteracting.SetBoolean(m_interactionCount > 0);
    }
}
