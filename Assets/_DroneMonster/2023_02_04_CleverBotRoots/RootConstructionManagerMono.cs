using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootConstructionManagerMono : MonoBehaviour
{

    public float m_segmentDistanceOfRoot=0.1f;

    [Header("Debug")]
    public GameObject m_lastCreatedRoot;
    public GameObject m_initialRoot;
    public List<GameObject> m_createdRoot;
    public Transform m_whereToStart;

    public void Kill()
    {
        foreach (var item in m_createdRoot)
        {
            GameObject.Destroy(item);
        }
        GameObject.Destroy(m_lastCreatedRoot);
        GameObject.Destroy(m_initialRoot);
        m_createdRoot = new List<GameObject>();
    }
    public void ResetMonsterAtZero()
    {
        Kill();
        CreateStartPointStartPointAtZeroWorld();
    }

    [ContextMenu("Create initial root")]
    public void CreateStartPointStartPointAtZeroWorld()
    {
        if (m_whereToStart == null)
        {
            CreateStartPoint(Vector3.zero, Quaternion.identity, out GameObject temp);
            temp.transform.forward = Vector3.up;
        }
        else {

            CreateStartPoint(m_whereToStart.position, m_whereToStart.rotation, out GameObject temp);
            temp.transform.forward = Vector3.up;
        }
    }
    public void CreateStartPoint(Vector3 position, Quaternion  rotation, out GameObject created)
    {
            RootNodeFactory.creationDObjet(position, rotation, out created);
            m_initialRoot = created;
        m_lastCreatedRoot = created;
        m_createdRoot.Add(created);
    }

    [ContextMenu("Create root forward")]
    public void CreateRootInDirectionForward()
    {
        CreateRootInDirectionForward(out GameObject temp);
    }

    public void CreateRootInDirectionForward(out GameObject created)
    {

        CreateRootInDirection(m_lastCreatedRoot.transform.position
            + m_lastCreatedRoot.transform.forward * (m_segmentDistanceOfRoot * 1.3f),
            out created);
    }
    [ContextMenu("Create root randomly forward")]
    public void CreateRootInDirectionRandomlyForward()
    {
        CreateRootInDirectionRandomlyForward( 30, out GameObject temp);
    }

    public void CreateRootInDirectionRandomlyForward(float randomAngle , out GameObject created)
    {
        Eloi.E_UnityRandomUtility.GetRandomN2M(-randomAngle, randomAngle, out float xAxis);
        Eloi.E_UnityRandomUtility.GetRandomN2M(-randomAngle, randomAngle, out float zAxis);
        Vector3 forwardRandom = Quaternion.Euler(xAxis, 0, zAxis) * m_lastCreatedRoot.transform.forward;

        CreateRootInDirection(m_lastCreatedRoot.transform.position
            + forwardRandom * (m_segmentDistanceOfRoot * 1.3f),
            out created);
    }


    public void CreateRootInDirection(Vector3 pointWanted, out GameObject created)
    {
        if (m_initialRoot == null)
        {
            throw new System.Exception("Go create a root first dumb ass !!!");
        }

        GameObject previousPoint = m_lastCreatedRoot;
        Vector3 frontPlantPoint = GetPointInFrontOfObject(previousPoint);
        Vector3 directionToWantedpoint = pointWanted - frontPlantPoint;
        Debug.DrawLine(frontPlantPoint, frontPlantPoint + directionToWantedpoint, Color.red, 2);

        Quaternion oritentation = Quaternion.LookRotation(directionToWantedpoint);

        RootNodeFactory.creationDObjet(frontPlantPoint, oritentation, out created);
        created.transform.rotation = oritentation;
        created.SetActive(true);

        m_lastCreatedRoot = created;
        m_createdRoot.Add(created);

    }

    public void CreateRootInDirectionWithRandom(Vector3 pointWanted, float randomAngle, out GameObject created)
    {
        if (m_initialRoot == null)
        {
            throw new System.Exception("Go create a root first dumb ass !!!");
        }

        GameObject previousPoint = m_lastCreatedRoot;
        Vector3 frontPlantPoint = GetPointInFrontOfObject(previousPoint);
        Vector3 directionToWantedpoint = pointWanted - frontPlantPoint;
        Debug.DrawLine(frontPlantPoint, frontPlantPoint + directionToWantedpoint, Color.red, 2);

        Eloi.E_UnityRandomUtility.GetRandomN2M(-randomAngle, randomAngle, out float xAxis);
        Eloi.E_UnityRandomUtility.GetRandomN2M(-randomAngle, randomAngle, out float zAxis);
        directionToWantedpoint = Quaternion.Euler(xAxis, 0, zAxis) * directionToWantedpoint;

        Debug.DrawLine(frontPlantPoint, frontPlantPoint + directionToWantedpoint, Color.magenta, 2);

        Quaternion oritentation = Quaternion.LookRotation(directionToWantedpoint);

        RootNodeFactory.creationDObjet(frontPlantPoint, oritentation, out created);
        created.transform.rotation = oritentation;
        created.SetActive(true);
        m_lastCreatedRoot = created;
        m_createdRoot.Add(created);


    }   
    public Vector3 GetPointInFrontOfObject()
    {
        return GetPointInFrontOfObject(m_lastCreatedRoot, m_segmentDistanceOfRoot);
    }
    public Vector3 GetPointInFrontOfObject( float distance)
    {
        return m_lastCreatedRoot.transform.position + m_lastCreatedRoot.transform.forward * distance;
    }
    public Vector3 GetPointInFrontOfObject(GameObject previousPoint)
    {
        return GetPointInFrontOfObject(previousPoint, m_segmentDistanceOfRoot);
    }
    public Vector3 GetPointInFrontOfObject(GameObject previousPoint, float distance)
    {
        return previousPoint.transform.position + previousPoint.transform.forward * distance;
    }
}
