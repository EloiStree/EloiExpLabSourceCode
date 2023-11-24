using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowWallDirectionAnchorMono : MonoBehaviour
{

    public Transform m_whereToGrowDirection;
    public Transform m_growRoot;

    public Vector3 m_growingMinSize = Vector3.one * 1;
    public Vector3 m_growingMaxSize = Vector3.one * 10;
    public float m_maxGrowTime = 60;
    public float m_multiplicator=1;

    [Header("Don't touch")]
    public float m_timePasted;
   

    void Start()
    {
        m_timePasted = 0;
        m_growRoot.forward = m_whereToGrowDirection.position - m_growRoot.position;
        m_growRoot.localScale = m_growingMinSize;
    }

    void Update()
    {
        m_growRoot.forward = m_whereToGrowDirection.position - m_growRoot.position;
        m_timePasted += Time.deltaTime;
        float percent = Mathf.Clamp01( m_timePasted / m_maxGrowTime
            * m_multiplicator);
        Vector3 size =  Vector3.Lerp(m_growingMinSize, m_growingMaxSize, percent);
        m_growRoot.localScale = size;
    }
    private void Reset()
    {
        m_whereToGrowDirection = this.transform;
    }

    public void OnValidate()
    {
        Update();
       
    }

}
