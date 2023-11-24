using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionActionMono : MonoBehaviour
{

    public UnityEvent m_onCollisionDetected;
    public bool m_useLayerMask = true;
    public LayerMask m_allowCollision;
    //public bool m_useKillLayerTag=true;

    public static bool Contains( LayerMask mask, int layer)
    {
        return ((mask & (1 << layer)) != 0);
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    //m_collisionWith = other..GetComponent<GameObject>();

    //}
    public void OnCollisionEnter(Collision collision)
    {
       
        if(Contains(m_allowCollision, collision.gameObject.layer))
        //if(m_useKillLayerTag)
        //if(collision.gameObject.GetComponent<KillLayerTag>())
            m_onCollisionDetected.Invoke();
    }
}
