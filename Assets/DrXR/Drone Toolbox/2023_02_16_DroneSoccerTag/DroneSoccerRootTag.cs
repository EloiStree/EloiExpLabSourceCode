using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSoccerRootTag : MonoBehaviour
{
    public Transform m_root;

    public Transform GetRoot()
    {
        return m_root;
    }
    private void Reset()
    {
        m_root = this.transform; 
    }
}
