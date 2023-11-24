using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class QuickDirtyGameManagerMono : MonoBehaviour
{
    public UnityEvent m_spawnMonster;
    public UnityEvent m_killMonster;
    public UnityEvent m_reviveAllPlayer;

    public RelayMessageToPlayerMono m_players;
    public Eloi.PrimitiveUnityEvent_String m_lastWinnerName;

    public float m_countdownBeforeKillingTheMonster = 3;
    public float m_countdownBeforeRevive = 5;
    public float m_countdownRestart = 10;

    public Coroutine m_coroutine;

    public bool m_gameRunning;
    public void ReStartGame()
    {
        if (m_coroutine != null)
            StopCoroutine(m_coroutine);
        StartCoroutine(CoroutineResetartGame());
    }
    IEnumerator CoroutineResetartGame()
    {
        m_killMonster.Invoke();
        yield return new WaitForSeconds(m_countdownBeforeRevive);
        m_reviveAllPlayer.Invoke();
        yield return new WaitForSeconds(m_countdownRestart);
        m_spawnMonster.Invoke();
        m_gameRunning = true;
    }
    public void KillMonsterWaitThenReStartGame()
    {
        if (m_coroutine != null)
            StopCoroutine(m_coroutine);
        StartCoroutine(CoroutineKillMonsterWaitThenReStartGame());
    }
    IEnumerator CoroutineKillMonsterWaitThenReStartGame()
    {
        yield return new WaitForSeconds(m_countdownBeforeRevive);
        m_killMonster.Invoke();
        yield return new WaitForSeconds(m_countdownBeforeRevive);
        m_reviveAllPlayer.Invoke();
        yield return new WaitForSeconds(m_countdownRestart);
        m_spawnMonster.Invoke();
        m_gameRunning = true;
    }

    public List<GameObject> m_playersInGame;
    public List<GameObject> m_playersAlive;

    public int m_alivePlayerCount;
    public int m_previousAlivePlayerCount;

    void Update()
    {
        UpdatePlayerCountState();
        m_previousAlivePlayerCount = m_alivePlayerCount;
        m_alivePlayerCount = GetPlayerAliveCount();

        if (m_alivePlayerCount != m_previousAlivePlayerCount) {
            if (m_previousAlivePlayerCount > 0 && m_alivePlayerCount<1 )
            {
                KillMonsterWaitThenReStartGame();
                Debug.Log("Restart game");
            }
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
}
