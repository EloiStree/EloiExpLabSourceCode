using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnSphereCastActionMono : MonoBehaviour
{
   

        public UnityEvent m_onCollisionDetected;
        public bool m_useLayerMask = true;
        public LayerMask m_allowCollision;
    public float m_radius=0.1f;
        //public bool m_useKillLayerTag=true;

        public static bool Contains(LayerMask mask, int layer)
        {
            return ((mask & (1 << layer)) != 0);
        }
    //public void OnTriggerEnter(Collider other)
    //{
    //    //m_collisionWith = other..GetComponent<GameObject>();

    //}

    private void Update()
    {
        if(Physics.SphereCastAll(transform.position, m_radius, transform.forward, m_radius, m_allowCollision).Length>0)

            m_onCollisionDetected.Invoke(); 
    }


}
