using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;
    public VoidEventSO cameraShakeEvent;

    private void OnEnable()
    {
        cameraShakeEvent.OnEventRaised += OnCameraShakeEvent; 
    }

    private void OnDisable()
    {
        cameraShakeEvent.OnEventRaised -= OnCameraShakeEvent; 
    }

    private void OnCameraShakeEvent()
    {
        impulseSource.GenerateImpulse();
    }
}