using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchableToActionWithGlobalTimeMono : InteractableToActionWithGlobalTimeMono<TouchableObjectMono>
{

    public override void Reset()
    {
        base.Reset();
        m_interactionObserved = GetComponent<TouchableObjectMono>();
    }
}