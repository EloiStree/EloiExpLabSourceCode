using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootNodeFactory : MonoBehaviour
{
    public  GameObject[] m_brancheNodePrefab;
    public bool m_useZeroAsScale;
    public static Transform FirstPoint;
    //permet de declare la fabrique
    public static RootNodeFactory instance;

    public static List<Coordonate> InfoPoint = new List<Coordonate>() ;

    private void Reset()
    {
        InfoPoint.Add(new Coordonate(FirstPoint.position.x, FirstPoint.position.y, FirstPoint.position.z));
    }

    public void Awake()
    {
        instance = this;
    }

    public static void creationDObjet(Transform lieu, out GameObject nouveauObjet)
    {
        creationDObjet(lieu.position, lieu.rotation, out GameObject cree);

        nouveauObjet = cree;


        Transform temporaire = FirstPoint;

        temporaire.position = new Vector3(InfoPoint[InfoPoint.Count].X, InfoPoint[InfoPoint.Count].Y, InfoPoint[InfoPoint.Count].Z);

        creationDObjet(temporaire, out GameObject CreateObject);
    }

    public static void creationDObjet(Vector3 lieuPosition,Quaternion lieuRotation, out GameObject createdRoot)
    {
        
        int monRandom = Random.Range(0, instance.m_brancheNodePrefab.Length);

        createdRoot = GameObject.Instantiate(instance.m_brancheNodePrefab[monRandom]);
        createdRoot.transform.position = lieuPosition;
        createdRoot.transform.rotation = lieuRotation;
        if(instance.m_useZeroAsScale)
        createdRoot.transform.localScale = Vector3.zero;


    }


}



public class Coordonate
{
    public Coordonate(float X1, float Y1, float Z1)
    {
        X = X1;
        Y = Y1;
        Z = Z1;
    }

    float x = 0;
    float y = 0;
    float z = 0;

    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
    public float Z { get => z; set => z = value; }
}
