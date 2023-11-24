using Eloi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlySkytoUnityInputMono : MonoBehaviour
{

    public FlySkyToUnityInput m_input;

    public Eloi.PrimitiveUnityEvent_Float m_tiltPercentBackFront;
    public Eloi.PrimitiveUnityEvent_Float m_yawPercentLeftRightRotation;
    public Eloi.PrimitiveUnityEvent_Float m_rollPercentLeftRight;
    public Eloi.PrimitiveUnityEvent_Float m_throttlePercentDownUp;

    public PrimitiveUnityEventExtra_Bool m_onKillSwitchOn;
    public PrimitiveUnityEventExtra_Bool m_onDroneArmedOn;

    void Awake()
    {
        m_input = new FlySkyToUnityInput();
        m_input.Enable();
        m_input.DroneClassic.Enable();
        m_input.DroneClassic.PitchBackFront.performed += (InputAction.CallbackContext v)
        => { m_tiltPercentBackFront.Invoke(v.ReadValue<float>()); };
        m_input.DroneClassic.PitchBackFront.canceled += (InputAction.CallbackContext v)
            => { m_tiltPercentBackFront.Invoke(v.ReadValue<float>()); };

        m_input.DroneClassic.YawLeftRightRotation.performed += (InputAction.CallbackContext v)
            => { m_yawPercentLeftRightRotation.Invoke(v.ReadValue<float>()); };
        m_input.DroneClassic.YawLeftRightRotation.canceled += (InputAction.CallbackContext v)
            => { m_yawPercentLeftRightRotation.Invoke(v.ReadValue<float>()); };

        m_input.DroneClassic.RollLeftRight.performed += (InputAction.CallbackContext v)
            => { m_rollPercentLeftRight.Invoke(v.ReadValue<float>()); };
        m_input.DroneClassic.RollLeftRight.canceled += (InputAction.CallbackContext v)
            => { m_rollPercentLeftRight.Invoke(v.ReadValue<float>()); };

        m_input.DroneClassic.ThrottleDownUp.performed += (InputAction.CallbackContext v)
            => { m_throttlePercentDownUp.Invoke(v.ReadValue<float>()); };
        m_input.DroneClassic.ThrottleDownUp.canceled += (InputAction.CallbackContext v)
            => { m_throttlePercentDownUp.Invoke(v.ReadValue<float>()); };

        m_input.DroneClassic.KillSwitchOn.performed += (InputAction.CallbackContext v)
                    => { m_onKillSwitchOn.Invoke(v.ReadValueAsButton()); };
        m_input.DroneClassic.KillSwitchOn.canceled += (InputAction.CallbackContext v)
            => { m_onKillSwitchOn.Invoke(v.ReadValueAsButton()); };

        m_input.DroneClassic.ArmedSwitchOn.performed += (InputAction.CallbackContext v)
                    => { m_onDroneArmedOn.Invoke(v.ReadValueAsButton()); };
        m_input.DroneClassic.ArmedSwitchOn.canceled += (InputAction.CallbackContext v)
            => { m_onDroneArmedOn.Invoke(v.ReadValueAsButton()); };


    }

}
