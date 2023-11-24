using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopActivationMono : MonoBehaviour
{

    public GameObject[] m_toActivate;
    public int m_index;

    [ContextMenu("Next")]
    public void Next() {
        SetForAll(m_index);
        m_index++;
        if (m_index >= m_toActivate.Length)
            m_index =0;
    }

    private void SetForAll(int index)
    {
        for (int i = 0; i < m_toActivate.Length; i++)
        {
            m_toActivate[i].SetActive( i == index);
        }
    }

    [ContextMenu("Previous")]
    public void Previous() {
        SetForAll(m_index);
        m_index--;
        if (m_index <0)
            m_index = m_toActivate.Length-1;
    }
}
