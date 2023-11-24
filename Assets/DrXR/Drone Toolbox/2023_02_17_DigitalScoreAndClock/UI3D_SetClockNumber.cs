using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI3D_SetClockNumber : MonoBehaviour
{

    public int m_number;
    public UI3D_SetClockDigit [] m_digitsLeftToRight;
    public enum ClampType { ClampToBorder, Modulo}
    public ClampType m_clampType= ClampType.ClampToBorder;

    private void OnValidate()
    {
        SetWithNumber(m_number);
    }

    public void SetWithNumber(int number) {

        string t = "";
        for (int i = 0; i < m_digitsLeftToRight.Length; i++)
        {
            t += "9";
        }
        int.TryParse(t, out int maxValue);

        if (m_clampType == ClampType.ClampToBorder)
        {
            number = Mathf.Clamp(number, 0, maxValue);
        }
        else if (m_clampType == ClampType.Modulo)
        {
            maxValue += 1;
            number = number%maxValue;
        }
        string text = number.ToString();

        for (int i = 0; i < m_digitsLeftToRight.Length; i++)
        {
            int indexRightToLeft = m_digitsLeftToRight.Length - 1 - i;
            int indexTextRightToLeft = text.Length - 1 - i;
            if (indexTextRightToLeft >= 0)
            {
                m_digitsLeftToRight[indexRightToLeft].SetWithChar(text[indexTextRightToLeft]);
            }
            else {
                m_digitsLeftToRight[indexRightToLeft].SetWithChar('0');
            }
        }

    }
}
