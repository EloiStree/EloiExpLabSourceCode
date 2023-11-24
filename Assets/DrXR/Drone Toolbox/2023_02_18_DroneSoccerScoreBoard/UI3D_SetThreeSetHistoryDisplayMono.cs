
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI3D_SetThreeSetHistoryDisplayMono : MonoBehaviour
{
    public int m_redSet1Point;
    public int m_redSet2Point;
    public int m_redSet3Point;
    public int m_blueSet1Point;
    public int m_blueSet2Point;
    public int m_blueSet3Point;

    public Eloi.PrimitiveUnityEvent_Int m_onRedSet1Point;
    public Eloi.PrimitiveUnityEvent_Int m_onRedSet2Point;
    public Eloi.PrimitiveUnityEvent_Int m_onRedSet3Point;
    public Eloi.PrimitiveUnityEvent_Int m_onBlueSet1Point;
    public Eloi.PrimitiveUnityEvent_Int m_onBlueSet2Point;
    public Eloi.PrimitiveUnityEvent_Int m_onBlueSet3Point;

    private void Awake()
    {
        ResetToZero();
    }

    [ContextMenu("Reset To Zero")]
    public void ResetToZero() {

        for (int i = 1; i <= 3; i++)
        {
            SetTheMatchSetValue(i, 0,0);
        }
    }

    public void SetTheMatchSetValue(int setIndex1To3, int redScore, int blueScore)
    {
        SetRedPoint(setIndex1To3, redScore);
        SetBluePoint(setIndex1To3, blueScore);
    }


    public void SetRedPoint(int setIndex1To3, int setScore)
    {
        if (setIndex1To3 == 1)
        {
            m_redSet1Point = setScore; m_onRedSet1Point.Invoke(setScore);
        }
        if (setIndex1To3 == 2)
        {
            m_redSet2Point = setScore; m_onRedSet2Point.Invoke(setScore);
        }
        if (setIndex1To3 == 3)
        {
            m_redSet3Point = setScore; m_onRedSet3Point.Invoke(setScore);
        }
    }
    public void SetBluePoint(int setIndex1To3, int setScore)
    {
        if (setIndex1To3 == 1)
        {
            m_blueSet1Point = setScore; m_onBlueSet1Point.Invoke(setScore);
        }
        if (setIndex1To3 == 2)
        {
            m_blueSet2Point = setScore; m_onBlueSet2Point.Invoke(setScore);
        }
        if (setIndex1To3 == 3)
        {
            m_blueSet3Point = setScore; m_onBlueSet3Point.Invoke(setScore);
        }
    }

    private void OnValidate()
    {
        Refresh();
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        m_onRedSet1Point.Invoke(m_redSet1Point);
        m_onRedSet2Point.Invoke(m_redSet2Point);
        m_onRedSet3Point.Invoke(m_redSet3Point);

        m_onBlueSet1Point.Invoke(m_blueSet1Point);
        m_onBlueSet2Point.Invoke(m_blueSet2Point);
        m_onBlueSet3Point.Invoke(m_blueSet3Point);
    }
}
