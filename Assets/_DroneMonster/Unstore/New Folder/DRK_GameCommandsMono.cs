using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DRK_GameCommandsMono : MonoBehaviour
{


    public string m_lastReceived;

    public UnityEvent m_onKillMonster;
    public UnityEvent m_onSpawnMonster;
    public UnityEvent m_onReviveAllPlayer;
    public Vector3Event m_onRoomDimensionRequest;

    [System.Serializable]
    public class Vector3Event : UnityEvent<Vector3> { }
    public void TryToPushCommand(string commands) {
        m_lastReceived = commands;
        commands = commands.Trim().ToLower();
        if (commands.IndexOf("cmdadmin:") == 0) {
            commands = commands.Replace("cmdadmin:","");
            if (commands == "monsterkill" || commands == "killmonster" ) { m_onKillMonster.Invoke(); }
            if (commands == "monsterspawn" || commands == "spawnmonster" ) { m_onSpawnMonster.Invoke(); }
            if (commands == "reviveallplayer") { m_onReviveAllPlayer.Invoke(); }
            if (commands.IndexOf("room")==0) {
                string[] splitsToken = commands.Split(' ');
                if (splitsToken.Length >= 4) {

                    Vector3 dim = new Vector3();
                    float.TryParse(splitsToken[1], out dim.x);
                    float.TryParse(splitsToken[2], out dim.y);
                    float.TryParse(splitsToken[3], out dim.z);
                    m_onRoomDimensionRequest.Invoke(dim);
                }
            }
        }
    }
}
