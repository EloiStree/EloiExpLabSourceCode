using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRoomSizeMono : MonoBehaviour
{

    public Transform m_roomAffected;
    public Vector3 m_roomSize;

    public void Awake()
    {
        SetRoomSize(m_roomSize);
    }

    public void SetRoomSize(Vector3 roomSize) {
        m_roomSize = roomSize;
        m_roomAffected.transform.localScale = roomSize;
    }

    [ContextMenu("SetRoomAsDefaultSmall_3X3")]
    public void SetRoomAsDefaultSmall_3X3()
    {

        SetRoomSize(new Vector3(3f, 2.3f, 3f));
    }
    [ContextMenu("SetRoomAsDefaultMaxQuest_7X7")]
    public void SetRoomAsDefaultMaxQuest_7X7()
    {

        SetRoomSize(new Vector3(7f, 3f, 7f));
    }


    private void OnValidate()
    {
        SetRoomSize(m_roomSize);
    }
}
