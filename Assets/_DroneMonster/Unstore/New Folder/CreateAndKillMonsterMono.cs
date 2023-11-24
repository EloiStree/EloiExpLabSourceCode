using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreateAndKillMonsterMono : MonoBehaviour
{


    public Transform [] m_monsterSpawn;
    public GameObject m_lastCreation;

    public UnityEvent m_killMonster;
    public UnityEvent m_createMonster;

    [ContextMenu("Create Monster")]
    public void CreateMonsterStartPoint()
    {
        foreach (var item in m_monsterSpawn)
        {

            RootNodeFactory.creationDObjet(item, out m_lastCreation);
        }
        m_createMonster.Invoke();
    }
    [ContextMenu("Kill Monster")]
    public void KillTheMonster() 
    {

        GrowRootMonsterNodeTag[] allRootOfMonster = GameObject.FindObjectsOfType<GrowRootMonsterNodeTag>();
        for (int i = 0; i < allRootOfMonster.Length; i++)
        {
            Destroy(allRootOfMonster[i].gameObject);
        }
        m_killMonster.Invoke();
    }


}
