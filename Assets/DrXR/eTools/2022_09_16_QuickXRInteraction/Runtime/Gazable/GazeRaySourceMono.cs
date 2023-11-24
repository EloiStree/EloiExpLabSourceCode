using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GazeRaySourceMono : InteractionRaySourceMono<GazableObjectMono>
{
    protected override void Reset()
    {
        base.Reset();
        base.m_name = "Touch Ray Source";
        base.m_rayDistance = 0.05f;
    }
}