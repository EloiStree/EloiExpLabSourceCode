using Eloi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoccerMatchBoardManagerV0Mono : MonoBehaviour, SoccerMatchBasicArbiterActions
{


    public Context.Time.SecondAsFloat m_durationOfSetInMatch;

    public bool m_gameIsInPause;

    public int  m_redTeamCurrentScore;
    public int  m_blueTeamCurrentScore;
    public int  m_redTeamSet;
    public int  m_blueTeamSet;

    public float m_timeLeftForTheSet;
    public UnityEvent m_onValueChanged;
    public Eloi.PrimitiveUnityEvent_Float m_onTimeChanged;

    public UnityEvent m_onEndOfSet;


    [ContextMenu("AddMatchSetPointToBlue")]
    public void AddMatchSetPointToBlue() => AddMatchSetPointToBlue(1);

    public void AddMatchSetPointToBlue(int valueToAdd)
    {
        m_blueTeamSet += valueToAdd;
        m_onValueChanged.Invoke();
    }

    [ContextMenu("AddMatchSetPointToRed")]
    public void AddMatchSetPointToRed() => AddMatchSetPointToRed(1);
    public void AddMatchSetPointToRed(int valueToAdd)
    {
        m_redTeamSet += valueToAdd;
        m_onValueChanged.Invoke();
    }

    [ContextMenu("AddScorePointToBlue")]
    public void AddScorePointToBlue() => AddScorePointToBlue(1);

    public void AddScorePointToBlue(int valueToAdd)
    {
        if (!m_gameIsInPause) 
            m_blueTeamCurrentScore += valueToAdd;
        m_onValueChanged.Invoke();
    }

    [ContextMenu("AddScorePointToRed")]
    public void AddScorePointToRed() => AddScorePointToRed(1);
    public void AddScorePointToRed(int valueToAdd)
    {
        if (!m_gameIsInPause) 
            m_redTeamCurrentScore += valueToAdd;
        m_onValueChanged.Invoke();
    }

    [ContextMenu("PauseTheGame")]
    public void PauseTheGame()
    {
        m_gameIsInPause = true;
        m_onValueChanged.Invoke();
    }

    [ContextMenu("RestartTheGame")]
    public void RestartTheGame()
    {
        ResetBoardForNextMatch();
    }

    [ContextMenu("ResumeTheGame")]
    public void ResumeTheGame()
    {
        m_gameIsInPause = false;
        m_onValueChanged.Invoke();
    }

    public void SetTimeLeftToZero()    => SetTimeLeftToCustomTime(new Context.Time.SecondAsFloat(0));

    [ContextMenu("SetTimeLeftTo3Minutes")]
    public void SetTimeLeftTo3Minutes() => SetTimeLeftToCustomTime(new Context.Time.SecondAsFloat(180f));


    [ContextMenu("SetTimeLeftTo5Minutes")]
    public void SetTimeLeftTo5Minutes() => SetTimeLeftToCustomTime(new Context.Time.SecondAsFloat(300f) );

    public void SetTimeLeftToCustomTime(Context.Time.SecondAsFloat time)
    {
        m_timeLeftForTheSet = time.GetValue();
    }

    [ContextMenu("Flush to next Set")]
    public void FlushCurrentSetAndAddPointToBestTeam()
    {
        if (m_redTeamCurrentScore == m_blueTeamCurrentScore)
        {

        }
        else
        if (m_redTeamCurrentScore > m_blueTeamCurrentScore)
        {
            AddMatchSetPointToRed();
        }
        else
        if (m_redTeamCurrentScore < m_blueTeamCurrentScore)
        {
            AddMatchSetPointToBlue();
        }
        ResetBoardForNextSet();
    }

    public void ResetBoardForNextSet()
    {
        SetTimeLeftToCustomTime(m_durationOfSetInMatch);
        m_gameIsInPause = false;
        m_redTeamCurrentScore = 0;
        m_blueTeamCurrentScore = 0;
        m_onValueChanged.Invoke();
        m_onTimeChanged.Invoke(m_timeLeftForTheSet);
    }

    public void ResetBoardForNextMatch()
    {
        SetTimeLeftToCustomTime(m_durationOfSetInMatch);
        m_gameIsInPause = false;
        m_redTeamCurrentScore = 0;
        m_blueTeamCurrentScore = 0;
        m_redTeamSet = 0;
        m_blueTeamSet = 0;
        m_onValueChanged.Invoke();
        m_onTimeChanged.Invoke(m_timeLeftForTheSet);
    }
    [ContextMenu("Notify Changed")]
    public void NotifyChanged() {
        m_onValueChanged.Invoke();
        m_onTimeChanged.Invoke(m_timeLeftForTheSet);
    }

    public bool ScoreAreNotEqual()
    {
        return m_redTeamCurrentScore != m_blueTeamCurrentScore;
    }
    public bool ScoreAreEqual()
    {
        return m_redTeamCurrentScore == m_blueTeamCurrentScore;
    }

    public bool IsSetInProlongation()
    {
        return m_timeLeftForTheSet <= 0 && m_redTeamCurrentScore == m_blueTeamCurrentScore;
    }

    public int GetSetCount()
    {
        return m_blueTeamSet + m_redTeamSet;
    }

    public int GetCurrentBluePoint()
    {
        return m_blueTeamCurrentScore;
    }

    public int GetCurrentRedPoint()
    {
        return m_redTeamCurrentScore;
    }
}


public interface SoccerMatchBasicArbiterActions {

    public void PauseTheGame();
    public void ResumeTheGame();
    public void RestartTheGame();

    public void FlushCurrentSetAndAddPointToBestTeam();
    public void ResetBoardForNextSet();
    public void ResetBoardForNextMatch();

    public void SetTimeLeftToZero();
    public void SetTimeLeftTo3Minutes();
    public void SetTimeLeftTo5Minutes();
    public void SetTimeLeftToCustomTime(Eloi.Context.Time.SecondAsFloat time);


    public void AddScorePointToRed();
    public void AddScorePointToBlue();
    public void AddMatchSetPointToRed();
    public void AddMatchSetPointToBlue();

    public void AddScorePointToRed(int valueToAdd);
    public void AddScorePointToBlue(int valueToAdd);
    public void AddMatchSetPointToRed(int valueToAdd);
    public void AddMatchSetPointToBlue(int valueToAdd);



}
