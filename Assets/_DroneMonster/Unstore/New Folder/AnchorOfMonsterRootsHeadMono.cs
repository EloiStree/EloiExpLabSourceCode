using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorOfMonsterRootsHeadMono : MonoBehaviour
{
    public RootConstructionManagerMono m_constructor;
    public Transform m_headToMove;

    void Update()
    {
        if (m_constructor != null && m_constructor.m_lastCreatedRoot != null) {
            GameObject lastCreation = m_constructor.m_lastCreatedRoot;
            m_headToMove.position =
                Vector3.Lerp(m_headToMove.position, lastCreation.transform.position, Time.deltaTime);
            m_headToMove.rotation =
                Quaternion.Lerp(m_headToMove.rotation, lastCreation.transform.rotation, Time.deltaTime);
        }
    }
    private void Reset()
    {
        m_headToMove = transform;
    }
}
