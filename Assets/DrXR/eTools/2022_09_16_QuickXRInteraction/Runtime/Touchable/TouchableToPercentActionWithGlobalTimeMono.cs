using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchableToPercentActionWithGlobalTimeMono : InterActionToPercentActionWithGlobalTimeMono<TouchableObjectMono>
{
    protected override void Reset()
    {
        base.Reset();
        m_interactionObserved = GetComponent<TouchableObjectMono>();
    }
}
