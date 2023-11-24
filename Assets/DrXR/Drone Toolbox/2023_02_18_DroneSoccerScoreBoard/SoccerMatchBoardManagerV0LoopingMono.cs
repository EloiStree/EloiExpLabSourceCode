using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoccerMatchBoardManagerV0LoopingMono : MonoBehaviour
{

    public SoccerMatchBoardManagerV0Mono m_source;

    public float m_breazingTime = 10;

    public UnityEvent m_restartGameTrigger;

    public void Awake()
    {
        m_source.RestartTheGame();
        m_source.ResumeTheGame();

        m_restartGameTrigger.Invoke();
    }

    public void Update()
    {
        if (!m_source.m_gameIsInPause)
        {

          
            if (m_source.m_timeLeftForTheSet > 0f)
            {
                m_source.m_timeLeftForTheSet -= Time.deltaTime;
                if (m_source.m_timeLeftForTheSet <= 0f)
                {
                    m_source.m_timeLeftForTheSet = 0;

                    if (m_source.ScoreAreNotEqual())
                    {
                        m_source.m_onEndOfSet.Invoke();
                        m_source.FlushCurrentSetAndAddPointToBestTeam();
                        m_source.PauseTheGame();
                        Invoke("ResumeTheGame", m_breazingTime);
                    }
                }
                m_source.m_onTimeChanged.Invoke(m_source.m_timeLeftForTheSet);
            }
            else if (m_source.m_timeLeftForTheSet <=0f && m_source.ScoreAreNotEqual())
            {
                    m_source.m_onEndOfSet.Invoke();
                    m_source.FlushCurrentSetAndAddPointToBestTeam(); 
                m_source.PauseTheGame();
                    Invoke("ResumeTheGame", m_breazingTime);
            }
        }
    }

    public void ResumeTheGame()
    {
        if (m_source.GetSetCount() >= 3) { 
            m_source.RestartTheGame();
            m_restartGameTrigger.Invoke();
        }
        m_source.ResumeTheGame();

    }
    //public void RestartTheGame()
    //{
    //    m_source.RestartTheGame();
    //}
}

