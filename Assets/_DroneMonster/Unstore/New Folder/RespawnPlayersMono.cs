using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayersMono : MonoBehaviour
{
    public RelayMessageToPlayerMono m_playerOnServer;


    [ContextMenu("Revive All")]
    public void ReviveAllPlayers()
    {
        m_playerOnServer.GetAllPlayersInGame(out List<GameObject> ips);
        for (int i = 0; i < ips.Count ; i++)
        {
            ips[i].SetActive(true);
        }
    }

}
