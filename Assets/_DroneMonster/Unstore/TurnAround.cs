using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{

    public Transform m_objectToRotate;
    public Vector3 m_rotationType= Vector3.up;
    public float m_angle=360;
    public Space m_spaceType;
    void Start()
    {

        Debug.Log("Bonjour");
    }

    public int conteur = 0;

    void Update()
    {
        

        m_objectToRotate.Rotate(m_rotationType, m_angle * Time.deltaTime , m_spaceType);
        // Debug.Log("i: "+ conteur);
        conteur = conteur + 1;

    }
}
