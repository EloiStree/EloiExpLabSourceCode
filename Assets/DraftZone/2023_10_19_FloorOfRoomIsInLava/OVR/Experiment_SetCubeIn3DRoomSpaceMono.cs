//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.Events;

//public partial class Experiment_SetCubeIn3DRoomSpaceMono : MonoBehaviour
//{

//    public OVRSceneRoom m_roomInScene;
//    public List<OVRObjectInScene> m_allObjectInRoom = new();

//    internal void GetAllElementsNotSurrounding(out OVRObjectInScene[] elements)
//    {
//        Eloi.E_EnumUtility.GetAllEnumOf(out List<PossibleRoomTag> tags);
//        tags.Remove(PossibleRoomTag.CEILING);
//        tags.Remove(PossibleRoomTag.WALL_FACE);
//        tags.Remove(PossibleRoomTag.GLOBAL_MESH);
//        tags.Remove(PossibleRoomTag.FLOOR);
//        elements = GetSpecificElements(tags.ToArray()).ToArray();

//    }

//    public Dictionary<PossibleRoomTag, List<OVRObjectInScene>> m_dicoObjectInRoom = new();

    
//    public bool HasCeiling()
//    {
//        return m_dicoObjectInRoom.ContainsKey(PossibleRoomTag.CEILING) &&
//        m_dicoObjectInRoom[PossibleRoomTag.CEILING].Count > 0;
//    }
//    public bool HasSpecificElement(PossibleRoomTag searchedElement)
//    {
//        return m_dicoObjectInRoom.ContainsKey(searchedElement) &&
//        m_dicoObjectInRoom[searchedElement].Count > 0;
//    }
//    public OVRObjectInScene GetSpecificElementFirst(PossibleRoomTag searchedElement)
//    {
//        return m_dicoObjectInRoom[searchedElement][0];
//    }
//    public OVRObjectInScene[] GetSpecificElements(PossibleRoomTag searchedElement)
//    {
//        return m_dicoObjectInRoom[searchedElement].ToArray();
//    }
//    public List<OVRObjectInScene> GetSpecificElements(params PossibleRoomTag[] searchedElement)
//    {
//        List<OVRObjectInScene> result = new List<OVRObjectInScene>();
//        foreach (var element in searchedElement)
//        {
//            if (HasSpecificElement(element))
//                result.AddRange(GetSpecificElements(element));
//        }
//        return result;
//    }

//    public void GetFloor(out OVRObjectInScene floor)
//    {
//        floor = GetSpecificElementFirst(PossibleRoomTag.FLOOR);
//    }
//    public void GetCeiling(out OVRObjectInScene ceiling)
//    {
//        ceiling = GetSpecificElementFirst(PossibleRoomTag.CEILING);
//    }

//    public UnityEvent m_onFinishRefreshRoom;


//    public bool m_useAutoRefresh;
//    public float m_delayToRefresh = 3;
//    // Start is called before the first frame update
//    void Start()
//    {
//        if (m_useAutoRefresh)
//            Invoke("RefreshElementInRoom", m_delayToRefresh);
//    }

//    [ ContextMenu("Refresh element in the room")]
//    public void RefreshElementInRoom()
//    {
//        m_roomInScene = GameObject.FindObjectOfType<OVRSceneRoom>();
//        OVRSceneAnchor [] elementsInRoom = GameObject.FindObjectsOfType< OVRSceneAnchor>();
//        m_allObjectInRoom.Clear();
//        m_dicoObjectInRoom.Clear();
//        foreach (var e in elementsInRoom)
//        {
//            OVRObjectInScene sceneElement = new OVRObjectInScene();
//            ///sceneElement.m_tagEnum;
//            sceneElement.m_anchorRootMono = e;
//            sceneElement.m_sementicMono = e.GetComponent<OVRSemanticClassification>();
//            sceneElement.m_sceneVolumeMono = e.GetComponent<OVRSceneVolume>();
//            sceneElement.m_scenePlaneMono = e.GetComponent<OVRScenePlane>();
//            if (sceneElement.m_sementicMono != null)
//            {
//                sceneElement.m_tagRaw = sceneElement.m_sementicMono.Labels.ToArray();
//                sceneElement.m_tagEnum = Eloi.E_EnumUtility.GetEnumFromLabelString<PossibleRoomTag>(sceneElement.m_tagRaw, PossibleRoomTag.Unknow, true, true);
//                sceneElement.m_descriptionEditorLabel = string.Join(",", sceneElement.m_tagRaw);
//            }
//            m_allObjectInRoom.Add(sceneElement);
//            if (sceneElement.m_sementicMono != null) {
//                foreach (var etag in sceneElement.m_tagEnum)
//                {
//                    if (!m_dicoObjectInRoom.ContainsKey(etag)) {
//                        m_dicoObjectInRoom.Add(etag, new());
//                    }
//                    m_dicoObjectInRoom[etag].Add(sceneElement);
//                }
//            }
//        }
//        m_onFinishRefreshRoom.Invoke(); 
//    }

   
//}
