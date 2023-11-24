using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TouchableRaySourceMono : InteractionRaySourceMono<TouchableObjectMono>
{

    protected override void Reset()
    {
        base.Reset();
        base.m_name = "Touch Ray Source";
        base.m_rayDistance = 0.05f;
        base.m_radius = 0.05f;
    }
}
