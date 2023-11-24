using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SetLyn6CamTriCMaterialMono : MonoBehaviour
{
    public TextureEvent m_onLeftRgb;
    public TextureEvent m_onRightRgb;
    public TextureEvent m_onLeftHand;
    public TextureEvent m_onRightHand;
    public TextureEvent m_onLeftRoom;
    public TextureEvent m_onRightRoom;
    public class TextureEvent : UnityEvent<Texture> { }

     


}
