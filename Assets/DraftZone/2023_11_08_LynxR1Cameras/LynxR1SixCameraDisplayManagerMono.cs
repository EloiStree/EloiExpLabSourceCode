using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LynxR1SixCameraDisplayManagerMono : MonoBehaviour
{

    public GameObject m_rgbAnchor;
    public GameObject m_handAnchor;
    public GameObject m_roomAnchor;


    public void SwitchStateRandomly() {
        SwitchState(UnityEngine.Random.Range(0, 3));
    }

    public void SwitchState(int index) {

        index = index % 3;
        m_rgbAnchor.SetActive(index == 0);
        m_handAnchor.SetActive(index == 1);
        m_roomAnchor.SetActive(index == 2);
    }

    public void DisplayAll()
    {
        m_rgbAnchor.SetActive(true);
        m_handAnchor.SetActive(true);
        m_roomAnchor.SetActive(true);
    }
    public void HideAll()
    {
        m_rgbAnchor.SetActive(false);
        m_handAnchor.SetActive(false);
        m_roomAnchor.SetActive(false);
    }
}
