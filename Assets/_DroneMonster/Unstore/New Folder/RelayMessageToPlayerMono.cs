using System;
using System.Collections.Generic;
using UnityEngine;

public class RelayMessageToPlayerMono   
{
    public void GetAllPlayersInGame(out List<GameObject> m_playersInGame)
    {
        throw new NotImplementedException();
    }

    internal void PushMessageToPlayersUDP(string command)
    {
        throw new NotImplementedException();
    }
}
public class UDPRelayToPlayersInGameSingleton {
    public static RelayMessageToPlayerMono m_instanceInScene;
}