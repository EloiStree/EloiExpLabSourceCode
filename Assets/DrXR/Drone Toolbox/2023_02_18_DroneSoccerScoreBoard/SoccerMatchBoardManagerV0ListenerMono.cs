using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerMatchBoardManagerV0ListenerMono : MonoBehaviour
{
    public SoccerMatchBoardManagerV0Mono m_source;
    public Eloi.PrimitiveUnityEvent_Int          m_setRedSetPoint;
    public Eloi.PrimitiveUnityEvent_Int          m_setRedCurrentPoint;
    public Eloi.PrimitiveUnityEvent_Int          m_setBlueSetPoint;
    public Eloi.PrimitiveUnityEvent_Int          m_setBlueCurrentPoint;
    public Eloi.PrimitiveUnityEventExtra_Bool    m_setGamePause;
    [ContextMenu("Refresh From Source")]
    public void RefreshFromSource() {

        m_setRedSetPoint.Invoke(m_source.m_redTeamSet);
        m_setRedCurrentPoint.Invoke(m_source.m_redTeamCurrentScore);
        m_setBlueSetPoint.Invoke(m_source.m_blueTeamSet);
        m_setBlueCurrentPoint.Invoke(m_source.m_blueTeamCurrentScore);
        m_setGamePause.Invoke(m_source.m_gameIsInPause);
    }
   
}
