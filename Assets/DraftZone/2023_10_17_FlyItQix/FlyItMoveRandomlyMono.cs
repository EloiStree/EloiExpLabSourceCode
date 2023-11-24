using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyItMoveRandomlyMono : MonoBehaviour
{
    public Transform m_whatToMove;

    public float m_speed=4;


    public void ChangeDirection() {

        m_whatToMove.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(-360, 360), UnityEngine.Random.Range(-360, 360), UnityEngine.Random.Range(-360, 360)));

    }

    private void Update()
    {
        m_whatToMove.Translate(Vector3.forward*m_speed*Time.deltaTime, Space.Self);

    }

    private void Reset()
    {
        m_whatToMove = transform;
    }
}
