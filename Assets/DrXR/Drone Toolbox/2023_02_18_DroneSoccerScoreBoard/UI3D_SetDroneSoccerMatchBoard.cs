using Eloi;
using UnityEngine;

public class UI3D_SetDroneSoccerMatchBoard : MonoBehaviour
{
    public int m_redTeamCurrentScore;
    public int m_blueTeamCurrentScore;

    public int m_redTeamSet;
    public int m_blueTeamSet;


    public Context.Time.SecondAsFloat m_timeLeft;

    public Eloi.PrimitiveUnityEvent_Int m_onSetOfRedTeamSet;
    public Eloi.PrimitiveUnityEvent_Int m_onSetOfBlueTeamSet;
    public Eloi.PrimitiveUnityEvent_Int m_onSetOfRedTeamCurrentScore;
    public Eloi.PrimitiveUnityEvent_Int m_onSetOfBlueTeamCurrentScore;
    public Eloi.PrimitiveUnityEvent_Float m_onTimeLeftChangedInSeconds;

    public void SetRedTeamSetPoint(int setPoint) { m_redTeamSet = setPoint; m_onSetOfRedTeamSet.Invoke(setPoint); }
    public void SetBlueTeamSetPoint(int setPoint) { m_blueTeamSet = setPoint; m_onSetOfBlueTeamSet.Invoke(setPoint); }
    public void SetRedTeamCurrentScore(int setPoint) { m_redTeamCurrentScore = setPoint; m_onSetOfRedTeamCurrentScore.Invoke(setPoint); }
    public void SetBlueTeamCurrentScore(int setPoint) { m_blueTeamCurrentScore = setPoint; m_onSetOfBlueTeamCurrentScore.Invoke(setPoint); }

    public void SetTimeLeftInSeconds(float timeInSeconds) { SetTimeLeftInSeconds(new Context.Time.SecondAsFloat(timeInSeconds)); }
    public void SetTimeLeftInSeconds(Context.Time.SecondAsFloat timeLeft) {
        m_timeLeft = timeLeft;
        m_onTimeLeftChangedInSeconds.Invoke(m_timeLeft.GetValue());
    }

    public void ResetToDefault(bool refreshAfterReset=true) {
        m_redTeamCurrentScore = 0;
        m_blueTeamCurrentScore = 0;
        m_redTeamSet = 0;
        m_blueTeamSet =0;
        m_timeLeft.SetValue(300);

        if(refreshAfterReset)
        PushRefresh();
    }

    [ContextMenu("Push Refresh")]
    public void PushRefresh() {

        SetRedTeamSetPoint(m_redTeamSet);
        SetBlueTeamSetPoint(m_blueTeamSet);
        SetRedTeamCurrentScore(m_redTeamCurrentScore);
        SetBlueTeamCurrentScore(m_blueTeamCurrentScore);
        SetTimeLeftInSeconds(m_timeLeft);
    }

    private void OnValidate()
    {
        PushRefresh();
    }

}
