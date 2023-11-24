using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandomlyAtAwakeOnZ : MonoBehaviour
{

    public Transform m_toAffect;
 
    public void ApplyRandomRotation() {
        Eloi.E_UnityRandomUtility.GetRandomN2M(-360f, 360f, out float rotation);
        m_toAffect.Rotate(new Vector3(0, 0, rotation), Space.Self);

    }
}
