using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseRandomColorAtAwakeMono : MonoBehaviour
{
    public Eloi.ClassicUnityEvent_Color m_awakeColor;
    // Start is called before the first frame update
    void Start()
    {
        RandomColor();
    }

    [ContextMenu("Random Color")]
    private void RandomColor()
    {
        Color c = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        m_awakeColor.Invoke(c);
    }

}
