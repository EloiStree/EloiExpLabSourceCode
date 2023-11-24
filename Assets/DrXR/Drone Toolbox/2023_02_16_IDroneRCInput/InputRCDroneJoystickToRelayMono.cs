using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRCDroneJoystickToRelayMono : MonoBehaviour
{

    public RCDroneInput m_input;

    public Eloi.PrimitiveUnityEvent_Float m_tiltPercentBackFront;
    public Eloi.PrimitiveUnityEvent_Float m_yawPercentLeftRightRotation;
    public Eloi.PrimitiveUnityEvent_Float m_rollPercentLeftRight;
    public Eloi.PrimitiveUnityEvent_Float m_throttlePercentDownUp;
    private void Awake()
    {
        m_input = new RCDroneInput();
        m_input.Enable();
        m_input.DroneInput.Enable();
        m_input.DroneInput.TiltBackFront.performed += (InputAction.CallbackContext v)
            => { m_tiltPercentBackFront.Invoke(v.ReadValue<float>()); }; 
        m_input.DroneInput.TiltBackFront.canceled += (InputAction.CallbackContext v)
            => { m_tiltPercentBackFront.Invoke(v.ReadValue<float>()); }; 

        m_input.DroneInput.YawLeftRightHorizontal.performed += (InputAction.CallbackContext v)
            => { m_yawPercentLeftRightRotation.Invoke(v.ReadValue<float>()); }; 
        m_input.DroneInput.YawLeftRightHorizontal.canceled += (InputAction.CallbackContext v)
            => { m_yawPercentLeftRightRotation.Invoke(v.ReadValue<float>()); }; 

        m_input.DroneInput.RollLeftRight.performed += (InputAction.CallbackContext v)
            => { m_rollPercentLeftRight.Invoke(v.ReadValue<float>()); }; 
        m_input.DroneInput.RollLeftRight.canceled += (InputAction.CallbackContext v)
            => { m_rollPercentLeftRight.Invoke(v.ReadValue<float>()); }; 

        m_input.DroneInput.ThrottleDowTop.performed += (InputAction.CallbackContext v)
            => { m_throttlePercentDownUp.Invoke(v.ReadValue<float>()); }; 
        m_input.DroneInput.ThrottleDowTop.canceled += (InputAction.CallbackContext v)
            => { m_throttlePercentDownUp.Invoke(v.ReadValue<float>()); }; 
    }

}
