using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandTopDownInteractionMono : MonoBehaviour
{
    public Transform m_leftHand;
    public Transform m_rightHand;

    public float m_downTrigger=0.3f;
    public float m_topTrigger=1.75f;

    public Eloi.PrimitiveUnityEventExtra_Bool m_leftBottom;
    public Eloi.PrimitiveUnityEventExtra_Bool m_rightBottom;
    public Eloi.PrimitiveUnityEventExtra_Bool m_leftTop;
    public Eloi.PrimitiveUnityEventExtra_Bool m_rightTop;
    public DefaultBooleanChangeListener m_leftBottomBoolean;
    public DefaultBooleanChangeListener m_rightBottomBoolean;
    public DefaultBooleanChangeListener m_leftTopBoolean;
    public DefaultBooleanChangeListener m_rightTopBoolean;



    private void Update()
    {
        bool changed = false;
        m_leftBottomBoolean.SetBoolean(m_leftHand.position.z < m_downTrigger, out  changed);
        if (changed) m_leftBottom.Invoke(m_leftBottomBoolean.GetBoolean());
        m_rightBottomBoolean.SetBoolean(m_rightHand.position.z < m_downTrigger, out changed);
        if (changed) m_rightBottom.Invoke(m_rightBottomBoolean.GetBoolean());
        m_leftTopBoolean.SetBoolean(m_leftHand.position.z > m_topTrigger, out changed);
        if (changed) m_leftTop.Invoke(m_leftTopBoolean.GetBoolean());
        m_rightTopBoolean.SetBoolean(m_rightHand.position.z > m_topTrigger, out changed);
        if (changed) m_rightTop.Invoke(m_rightTopBoolean.GetBoolean());

    }                     

}
