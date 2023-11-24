using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Experiment_VibrationQuest : MonoBehaviour
{
    public float vibrationDuration = 5f; 
    public float vibrationIntensity = 1.0f;
    //[SerializeField] InputActionReference leftHapticAction;
    //[SerializeField] InputActionReference rightHapticAction;

     void Update()
    {
       

        // Check for input to trigger vibration
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            VibrateControllerXRInspectorValue();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            VibrationXR_AnimCurve c = m_randomAttempt[UnityEngine.Random.Range(0, m_randomAttempt.Length)];
            StartCoroutine(c.CoroutineCode());
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            VibrationXR_Random c = m_randomAttempts[UnityEngine.Random.Range(0, m_randomAttempts.Length)];
            StartCoroutine(c.CoroutineCode());
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(Coroutine_Scale());
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Coroutine_Sin());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Coroutine_RandomFrame());
        }
        
    }

    public uint m_channel=0;
    public float m_amplitude=1;
    public float m_duration=1;

    public AnimationCurve m_curve;

    public float m_frameTime = 0.1f;
    public VibrationXR_AnimCurve[] m_randomAttempt;
    [System.Serializable]
    public class VibrationXR_AnimCurve
    {
        public string m_nameId = "";
        public float m_duration = 1;
        public float m_frameTime = 0.1f;
        public AnimationCurve m_curve;
        public IEnumerator CoroutineCode()
        {

            float start = Time.time;
            float now = Time.time;
            float percent = 0;
            while (now - start < m_duration)
            {
                now = Time.time;
                percent = (now - start) / m_duration;
                yield return new WaitForEndOfFrame();
                yield return new WaitForSeconds(m_frameTime);
                VibrateControllerXR(Mathf.Clamp01(m_curve.Evaluate(percent)), m_frameTime);
            }

        }
    }
    public VibrationXR_Random[] m_randomAttempts;
    [System.Serializable]
    public class VibrationXR_Random
    {
        public string m_nameId = "";
        public float m_duration = 1;
        public float m_intencityMin = 0.2f;
        public float m_intencityMax = 1;
        public float m_frameTimeMin = 0.02f;
        public float m_frameTimeMax = 0.15f;
        public IEnumerator CoroutineCode()
        {

            float start = Time.time;
            float now = Time.time;
            float percent = 0;
            while (now - start < m_duration)
            {
                now = Time.time;
                percent = (now - start) / m_duration;
                yield return new WaitForEndOfFrame();
                float ft = Random.Range(m_frameTimeMin, m_frameTimeMax);
                yield return new WaitForSeconds(ft);
                VibrateControllerXR(Mathf.Clamp01(Random.Range(m_intencityMin, m_intencityMax)), ft);
            }

        }
    }
    public IEnumerator Coroutine_Scale()
    {

        float start = Time.time;
        float now = Time.time;
        float percent = 0;
        while (now - start < m_duration)
        {
            now = Time.time;
            percent = (now - start) / m_duration;
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_frameTime);
            VibrateControllerXR(percent, m_frameTime);
        }

    }
    public IEnumerator Coroutine_RandomFrame()
    {

        float start = Time.time;
        float now = Time.time;
        float percent = 0;
        while (now - start < m_duration)
        {
            now = Time.time;
            percent = (now - start) / m_duration;
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_frameTime);
            VibrateControllerXR(Random.value, m_frameTime);
        }

    }
    public float m_sinFrequence=5;
    public IEnumerator Coroutine_Sin()
    {

        float start = Time.time;
        float now = Time.time;
        float percent = 0;
        while (now - start < m_duration)
        {
            now = Time.time;
            percent = (now - start) / m_duration;
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_frameTime);
            VibrateControllerXR(Mathf.Sin(percent/ m_sinFrequence), m_frameTime);
        }

    }
    
    public IEnumerator Coroutine_AnimCurve()
    {

        float start = Time.time;
        float now = Time.time;
        float percent = 0;
        while (now - start < m_duration)
        {
            now = Time.time;
            percent = (now - start) / m_duration;
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_frameTime);
            VibrateControllerXR(m_curve.Evaluate(percent), m_frameTime) ;
        }

    }
    private void VibrateControllerXRInspectorValue()
    {
        VibrateControllerXR(m_amplitude, m_duration);
    }
    public static void VibrateControllerXR(float amplitude, float duration, uint channel=0)
    {
        // Get the list of input devices
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevices(devices);

        foreach (var device in devices)
        {

            if (device.characteristics.HasFlag(InputDeviceCharacteristics.Controller))
            {

                device.TryGetHapticCapabilities(out HapticCapabilities capabilities);
                device.SendHapticImpulse(channel, amplitude, duration);
            }
        }
    }

    public string[] m_devicesName;
    //private void VibrateControllerXRBuffer()
    //{
    //    List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
    //    InputDevices.GetDevices(devices);

    //    foreach (var device in devices)
    //    {
    //        if (device.characteristics.HasFlag(InputDeviceCharacteristics.Controller))
    //        {
    //            device.TryGetHapticCapabilities(out HapticCapabilities capabilities);
    //            //uint max = capabilities.bufferMaxSize;
    //            uint hz = capabilities.bufferFrequencyHz;
    //            m_supportsBuffer = capabilities.supportsBuffer;
    //            m_buffer = GeneratePulseBuffer(m_amplitude, m_duration, hz);
    //            device.SendHapticBuffer(m_channel, m_buffer);
    //        }
    //    }
    //}
    //protected virtual byte[] GeneratePulseBuffer(float intensity, float duration,uint bufferFrequencyHz)
    //{
    //    int clipCount = (int)(bufferFrequencyHz * duration);
    //    byte[] clip = new byte[clipCount];
    //    for (int index = 0; index < clipCount; index++)
    //    {
    //        //clip[index] = (byte)(byte.MaxValue * intensity * m_curve.Evaluate(index / (float)clipCount));
    //        clip[index] = (byte)(byte.MaxValue * intensity * UnityEngine.Random.value);
    //    }
    //    return clip;

    //}
}

