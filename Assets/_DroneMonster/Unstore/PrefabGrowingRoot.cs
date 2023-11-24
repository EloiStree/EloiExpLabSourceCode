using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGrowingRoot : MonoBehaviour
{

    public float m_timeBeforeGrowing = 2;
    public Transform[]  m_growingStartPoint;
   // public GameObject [] m_whatToGrow;

    public bool m_autoDestroyScript;
    public float m_autoDestructionTime=60;

    void Start()
    {
        //Invoke("CreateGrow", m_timeBeforeGrowing);  
        InvokeRepeating("CreateGrow",0, m_timeBeforeGrowing);  
    }

    void CreateGrow()
    {

        if (m_growingStartPoint.Length == 0)
            return;
        Transform whereToCreate = m_growingStartPoint[Random.Range(0, m_growingStartPoint.Length)];
        RootFactoryMono.CreateRandomRoot(whereToCreate, out GameObject created);

        Destroy(created, m_autoDestructionTime);

        //if (m_whatToGrow.Length == 0)
        //    return;

        //GameObject whatToGrow = m_whatToGrow[Random.Range(0, m_whatToGrow.Length)];
        //GameObject createdObject =  GameObject.Instantiate(whatToGrow);
        //createdObject.transform.position = m_growingStartPoint.position;
        //createdObject.transform.localScale = m_growingStartPoint.localScale;
        //createdObject.transform.rotation = m_growingStartPoint.rotation;

        //Destroy(whatToGrow, m_autoDestructionTime);
        //if(m_autoDestroyScript)
        //Destroy(this);
    }
}


