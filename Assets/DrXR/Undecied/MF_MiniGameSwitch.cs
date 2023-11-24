using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MF_MiniGameSwitch : MonoBehaviour
{
    public bool m_useMiniGame;
    public Eloi.PrimitiveUnityEventExtra_Bool m_switchMiniGameOn;


    public void SetMiniGameOn(bool setGameOn) {
        m_useMiniGame = setGameOn;
        m_switchMiniGameOn.Invoke(setGameOn);
    }
    public void SwitchMiniGameState()
    {
        SetMiniGameOn(!m_useMiniGame);
    }
    public void SetGameOff()
    {
        SetMiniGameOn(false);
    }
    public void SetGameOn()
    {
        SetMiniGameOn(true);
    }
}
