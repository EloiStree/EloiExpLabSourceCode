using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverGazeSourceMono : MonoBehaviour
{
    public GazableObjectMono m_linkedGaze;
    public string m_id;
    public string m_name;

    public void OnMouseOver()
    {
        m_linkedGaze.SetInteractingSource(m_id, m_name);
    }
    private void OnMouseEnter()
    {
        m_linkedGaze.SetInteractingSource(m_id, m_name);
    }

    private void OnMouseExit()
    {

        m_linkedGaze.RemoveInteractingSource(m_id);

    }
    public void Awake()
    {
        InteractionGuidRegisterStatic.AddInteractionSource(m_id, this);
    }

    public void OnDestroy()
    {
        InteractionGuidRegisterStatic.RemoveInteractionSource(m_id);
    }

    private void Reset()
    {
        m_linkedGaze = GetComponent<GazableObjectMono>();
        m_id = System.Guid.NewGuid().ToString();
        m_name = "Mouse Over Source";
    }
}
