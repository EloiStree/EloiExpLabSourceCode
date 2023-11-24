using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3D_SetLedColorOfDigit : MonoBehaviour
{
    public Color m_colorChoosed= Color.red;
    public Eloi.ClassicUnityEvent_Color m_onColorChanged;
    public void SetColorOfDigit(Color newColor) {

        m_onColorChanged.Invoke(newColor);
    }
    [ContextMenu("SetRed")]
    public void SetRed() => SetColorOfDigit( Eloi.E_ColorUtility.RGBCodesChart.red);
    [ContextMenu("SetGreen")]
    public void SetGreen() => SetColorOfDigit(Eloi.E_ColorUtility.RGBCodesChart.green);
    [ContextMenu("SetYellow")]
    public void SetYellow() => SetColorOfDigit(Eloi.E_ColorUtility.RGBCodesChart.yellow);

    public void SetWithFFFFFF(string colorHexa) {
        Eloi.E_ColorUtility.ConvertHashFFFFFFFFToColor(colorHexa, out bool converted, out Color c);
        SetColorOfDigit(c);
    }

}
