using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnWallsMono : MonoBehaviour
{

    public Transform m_roomTargeted;
    public Transform m_parentToCreateIn;
    public GameObject m_prefabToCreate;
    public Space m_scaleType;
    public Transform m_targetToObserve;

    [ContextMenu("Spawn Randomly")]
    public void SpawnRandomly() {
        Eloi.E_UnityRandomUtility.GetRandomPositionInTransformWalls(in m_roomTargeted, out Vector3 randomPoint, m_scaleType);
        Eloi.E_UnityRandomUtility.GetRandomQuaternion(out Quaternion rotation);
        GameObject prefab = GameObject.Instantiate(m_prefabToCreate);
        prefab.transform.rotation = rotation;
        prefab.transform.position = randomPoint;
        prefab.transform.parent = m_parentToCreateIn;
        prefab.SetActive(true);
        if (m_targetToObserve != null)
            prefab.transform.LookAt(m_targetToObserve.position);
        else
            prefab.transform.LookAt(m_roomTargeted.position);
    }

}
