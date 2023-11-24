using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpFollowTargetMono : MonoBehaviour
{
    public Transform m_target;
    public Transform m_toAffect;
    void Update()
    {
        m_toAffect.position = Vector3.Lerp(m_toAffect.position, m_target.position, Time.deltaTime);
        m_toAffect.rotation = Quaternion.Lerp(m_toAffect.rotation, m_target.rotation, Time.deltaTime);
    }
}
