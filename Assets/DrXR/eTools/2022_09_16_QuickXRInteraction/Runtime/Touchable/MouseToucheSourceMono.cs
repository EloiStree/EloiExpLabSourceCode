using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToucheSourceMono : MonoBehaviour
{
    public TouchableObjectMono m_linkedTouchable;
    public string m_id;
    public string m_name= "Mouse Touch Source";

    public void Awake()
    {InteractionGuidRegisterStatic.AddInteractionSource(m_id, this); }

    public void OnDestroy()
    {InteractionGuidRegisterStatic.RemoveInteractionSource(m_id); }

    private void OnMouseDown()
    {        m_linkedTouchable.SetInteractingSource(m_id, m_name);   }
    private void OnMouseUp()
    {
        m_linkedTouchable.RemoveInteractingSource(m_id);

    }
   
    private void Reset()
    {
        m_linkedTouchable = GetComponent<TouchableObjectMono>();
        m_id = System.Guid.NewGuid().ToString();
    }
}
