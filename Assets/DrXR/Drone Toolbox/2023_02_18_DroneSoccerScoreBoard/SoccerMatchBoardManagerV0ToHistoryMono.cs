using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerMatchBoardManagerV0ToHistoryMono : MonoBehaviour
{
    public SoccerMatchBoardManagerV0Mono m_source;
    public UI3D_SetThreeSetHistoryDisplayMono m_historyDisplay;

    [ContextMenu("Refresh")]
    public void Refresh() {

        int index = m_source. GetSetCount()+1;
        m_historyDisplay.SetTheMatchSetValue(index, m_source.GetCurrentRedPoint(), m_source.GetCurrentBluePoint());

    }
    [ContextMenu("Reset To Zero History")]
    public void ResetToZeroHistory() {
        m_historyDisplay.ResetToZero();
    }
}
