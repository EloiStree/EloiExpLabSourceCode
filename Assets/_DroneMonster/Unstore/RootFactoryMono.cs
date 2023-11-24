using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootFactoryMono : MonoBehaviour
{

    public GameObject [] m_rootRangeOfPrefab;

    public static RootFactoryMono instance;

    public void Awake()
    {
        instance = this;
    }

    public static void CreateRandomRoot(Transform where, out GameObject created)
    {

        CreateRandomRoot(where.position, where.rotation, out created);
    }
    public static void CreateRandomRoot(Vector3 wherePosition, Quaternion whereRotation, out GameObject created)
    {
        if (instance.m_rootRangeOfPrefab.Length == 0) {
            created = null;          
            return;
        }

        GameObject whatToGrow = instance.m_rootRangeOfPrefab[Random.Range(0, instance.m_rootRangeOfPrefab.Length)];
        GameObject createdObject = GameObject.Instantiate(whatToGrow);
        createdObject.transform.position = wherePosition;
        createdObject.transform.rotation = whereRotation;
        created = createdObject;

    }

    public  static void GetAllCreatedRoots(out List<GameObject> createdRoot)
    {
        throw new System.NotImplementedException();
        //You need to creat that with your list.
    }
}
