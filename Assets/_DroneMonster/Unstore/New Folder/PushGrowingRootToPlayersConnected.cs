using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushGrowingRootToPlayersConnected : MonoBehaviour
{

    public GrowProgressif m_growingRoot;
    public GrowingRootInformation m_lastSent;
    public string m_prefabId;
    public void PushToPlayersGrowingRootInfo() {

        m_lastSent.m_prefabIdName = ""+ m_prefabId;
        m_lastSent.m_localStartPosition = m_growingRoot.m_whatToGrow.localPosition;
        m_lastSent.m_localStartRotation = m_growingRoot.m_whatToGrow.localRotation;
        m_lastSent.m_localStartDirection = m_growingRoot.m_whatToGrow.localRotation * Vector3.forward ;
        m_lastSent.m_timeToGrow = m_growingRoot.m_timeToGrowMax;
        m_lastSent.m_startSize = m_growingRoot.m_minValue;
        m_lastSent.m_endSize = m_growingRoot.m_maxValue;
        string cmd = "#ROOTGROWINGINF\n";
        cmd += JsonUtility.ToJson(m_lastSent);
        UDPRelayToPlayersInGameSingleton.m_instanceInScene.PushMessageToPlayersUDP(cmd);
    }

    [System.Serializable]
    public class GrowingRootInformation {
        public string m_prefabIdName;
        public Vector3 m_localStartPosition;
        public Quaternion m_localStartRotation;
        public Vector3 m_localStartDirection;
        public float m_timeToGrow;
        public Vector3 m_startSize;
        public Vector3 m_endSize;
    }
}



