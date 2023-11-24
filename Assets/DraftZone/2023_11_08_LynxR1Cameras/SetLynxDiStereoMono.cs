using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLynxDiStereoMono : MonoBehaviour
{
    public Texture m_leftTexture;
    public Texture m_rightTexture;
    public Material m_targetMaterial;
    public string m_materialLeftName = "Left";
    public string m_materialRightName = "Right";


    public void SetLeftTexture(Texture left)
    {
        m_leftTexture = left;
    }
    public void SetRightTexture(Texture right)
    {
        m_rightTexture = right;
    }
    public void SetTextureS(Texture left, Texture right)
    {
        m_leftTexture = left;
        m_rightTexture = right;
    }

    public void Refresh() {
        m_targetMaterial.SetTexture(m_materialLeftName, m_leftTexture);
        m_targetMaterial.SetTexture(m_materialRightName, m_rightTexture);

    }
}
