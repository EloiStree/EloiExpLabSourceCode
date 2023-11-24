using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;




public class AnyInteractionRaySourceMono : InteractionRaySourceMono<InteractableObjectMono>
{

}

public class InteractionRaySourceMono<T> : MonoBehaviour where T : InteractableObjectMono
{
    public string m_id;
    public string m_name = "Sphere Cast Source";
    public LayerMask m_allowToTouch = -1;
    public Transform m_rayDirection;
    public float m_rayDistance = 3000f;
    public float m_radius = 0.1f;
    public bool m_useDebugDraw;
    public Color m_debugColor = Color.red;
    public List<T> m_previous = new List<T>();
    public List<T> m_current = new List<T>();
    public bool m_passThrough=true;


    protected virtual void Reset()
    {
        m_rayDirection = this.transform;
        m_id = System.Guid.NewGuid().ToString();
    }

    private void Update()
    {
        if (m_passThrough)
            TriggerRayCast();
        else
            TriggerRayCastAll();
    }
    private void TriggerRayCast()
    {
        if (m_useDebugDraw)
            Debug.DrawLine(m_rayDirection.position, m_rayDirection.position + m_rayDirection.forward * m_rayDistance, m_debugColor);

        m_previous = m_current.ToList();
        m_current.Clear();
        RaycastHit[] hits = new RaycastHit[1];
        Physics.SphereCast(m_rayDirection.position, m_radius, m_rayDirection.forward, out hits[0], m_rayDistance, m_allowToTouch);

        for (int i = 0; i < hits.Length; i++)
        {
            T gazable = hits[i].collider.GetComponentInChildren<T>();
            if (gazable != null)
            {
                gazable.SetInteractingSource(m_id, m_name);
                m_current.Add(gazable);
                m_previous.Remove(gazable);
            }
        }
        UnhookPrevious();
    }
    private void TriggerRayCastAll()
    {
        if (m_useDebugDraw)
            Debug.DrawLine(m_rayDirection.position, m_rayDirection.position + m_rayDirection.forward * m_rayDistance, m_debugColor);

        m_previous = m_current.ToList();
        m_current.Clear();
        RaycastHit[] hits = Physics.SphereCastAll(m_rayDirection.position, m_radius, m_rayDirection.forward, m_rayDistance, m_allowToTouch);
        for (int i = 0; i < hits.Length; i++)
        {
            T gazable = hits[i].collider.GetComponentInChildren<T>();
            if (gazable != null)
            {
                gazable.SetInteractingSource(m_id, m_name);
                m_current.Add(gazable);
                m_previous.Remove(gazable);
            }
        }
        UnhookPrevious();
    }
    public void Awake()
    {
        InteractionGuidRegisterStatic.AddInteractionSource(m_id, this);
    }

    public void OnDestroy()
    {
        TriggerRayCast();
        UnhookPrevious();
        UnhookCurrent();
        InteractionGuidRegisterStatic.RemoveInteractionSource(m_id);
    }

    private void UnhookPrevious()
    {
        for (int i = 0; i < m_previous.Count; i++)
        {
            if (m_previous[i] != null)
                m_previous[i].RemoveInteractingSource(m_id);
        }
    }
    private void UnhookCurrent()
    {
        for (int i = 0; i < m_current.Count; i++)
        {
            if (m_current[i] != null)
                m_current[i].RemoveInteractingSource(m_id);
        }
    }
}
