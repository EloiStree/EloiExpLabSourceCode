using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float timeScene;
    public float TimerInterval = 5f;
    
    void Update()
    {
        timeScene = Time.time;
        int Temps = (int)(timeScene * 100);
        float tempsSecondly = (float)Temps / 100;
        int AfficheMM = Temps%100;
         

        GetComponent<Text>().text = string.Format("{0:0} : {1:00} : {2:00}", Mathf.Floor(tempsSecondly/59), tempsSecondly%59 , AfficheMM );          // (tempsSecondly).ToString();

        
    }
}
