using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class QuickDrityTimeScoreMono : MonoBehaviour
{

    public RelayMessageToPlayerMono m_players;
    public float m_gameTime;
    public float m_gameTimeSolo;
    public float m_gameTimeTeam;

    public float m_gameTimeSoloBest;
    public float m_gameTimeTeamBest;
    
    
     public Eloi.PrimitiveUnityEvent_Float m_gameTimeChanged;
     public Eloi.PrimitiveUnityEvent_Float m_gameTimeSoloChanged;
     public Eloi.PrimitiveUnityEvent_Float m_gameTimeTeamChanged;
    public Eloi.PrimitiveUnityEvent_Float m_gameTimeSoloBestChanged;
    public Eloi.PrimitiveUnityEvent_Float m_gameTimeTeamBestChanged;
    public Eloi.PrimitiveUnityEvent_Float m_gameTimeSoloPreviousChanged;
    public Eloi.PrimitiveUnityEvent_Float m_gameTimeTeamPreviousChanged;







    public List<GameObject> m_playersInGame;
    public List<GameObject> m_playersAlive;

    public int m_alivePlayerCount;
    public int m_previousAlivePlayerCount;

    void Update()
    {
        UpdatePlayerCountState();
        m_previousAlivePlayerCount = m_alivePlayerCount;
        m_alivePlayerCount = GetPlayerAliveCount();

        float deltaTime = Time.deltaTime;

      

        if (m_alivePlayerCount > 1)
        {
            m_gameTimeTeam += deltaTime;
        }
        if (m_alivePlayerCount >0)
        {
            m_gameTime += deltaTime;
            m_gameTimeSolo += deltaTime;
        }
        CheckForBestScore();


        if (m_alivePlayerCount != m_previousAlivePlayerCount)
        {
            if (m_alivePlayerCount == 0) {

                m_gameTime =0;
                m_gameTimeSolo = 0;
                m_gameTimeTeam = 0;
            }

        }
        m_gameTimeChanged.Invoke(m_gameTime);
        m_gameTimeSoloChanged.Invoke(m_gameTimeSolo);
        m_gameTimeTeamChanged.Invoke(m_gameTimeTeam);
        m_gameTimeSoloBestChanged.Invoke(m_gameTimeSoloBest);
        m_gameTimeTeamBestChanged.Invoke(m_gameTimeTeamBest);
    }

    private void CheckForBestScore()
    {
        if (m_gameTimeSolo > m_gameTimeSoloBest)
        {
            m_gameTimeSoloBest = m_gameTimeSolo;
        }
        if (m_gameTimeTeam > m_gameTimeTeamBest)
        {
            m_gameTimeTeamBest = m_gameTimeTeam;
        }
    }

    private int GetPlayerAliveCount()
    {

        return m_playersAlive.Count;
    }

    private bool HasPlayerInGame()
    {
        return m_playersInGame.Count > 1;
    }

    private void UpdatePlayerCountState()
    {
        m_players.GetAllPlayersInGame(out m_playersInGame);
        m_playersAlive = m_playersInGame.Where(k => k.activeInHierarchy).ToList();

    }

    
    [ContextMenu("ResetSaveScoreOnDevice")]
    public void ResetSaveScoreOnDevice()
    {
        m_gameTimeSoloBest = 0;
        m_gameTimeTeamBest = 0; 
        SaveScoreOnDevice();
    }

    private void Awake() => LoadScoreOnDevice();
    private void OnEnable() => LoadScoreOnDevice();
    private void OnDisable() => SaveScoreOnDevice();
    private void OnApplicationQuit()=> SaveScoreOnDevice();
    
    private void OnApplicationPause(bool pause) => SaveScoreOnDevice();
    

    public void SaveScoreOnDevice()
    {
        PlayerPrefs.SetFloat("BestSoloScore", m_gameTimeSoloBest);
        PlayerPrefs.SetFloat("BestTeamScore", m_gameTimeTeamBest);

    }
    public void LoadScoreOnDevice()
    {
        if (PlayerPrefs.HasKey("BestSoloScore"))
            m_gameTimeSoloBest = PlayerPrefs.GetFloat("BestSoloScore" );
        if (PlayerPrefs.HasKey("BestTeamScore")) 
            m_gameTimeTeamBest = PlayerPrefs.GetFloat("BestTeamScore");

        m_gameTimeSoloBestChanged.Invoke(m_gameTimeSoloBest);
        m_gameTimeTeamBestChanged.Invoke(m_gameTimeTeamBest);

    }

}
