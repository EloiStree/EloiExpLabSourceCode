using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleEffectLandingScenePositionMono : MonoBehaviour
{

    public Transform m_targetPosition;
    public Material m_targetMaterial;
  
    void Update()
    {
        if(m_targetPosition && m_targetMaterial)
            m_targetMaterial.SetVector("_Position", m_targetPosition.position);
    }
}
