using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MF_TeleportPlayerDroneToRespawnMono : MonoBehaviour
{

    public Transform[] m_drones;
    public Transform m_respawnPoint;


    public void ResetDroneAtRespawn() {
        for (int i = 0; i < m_drones.Length; i++)
        {
            m_drones[i].transform.position = m_respawnPoint.position;
            m_drones[i].transform.rotation = m_respawnPoint.rotation;
        }
    }
}
