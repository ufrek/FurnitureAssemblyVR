using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class ButtonInputController : MonoBehaviour
{
    public XRNode inputSource;
    public UnityEvent ButtonDownEvent = new UnityEvent();
    public UnityEvent ButtonUpEvent = new UnityEvent();
    public UnityEvent ButtonHeldEvent = new UnityEvent();
    [SerializeField]
    private bool isTrigger;
    [SerializeField]
    private bool isTriggerHeld = false;
    InputDevice device;
    void Update()
    {
        device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out isTrigger);

        if (isTrigger)
        {
            if (isTriggerHeld)
            {
                ButtonHeldEvent.Invoke();
            }
            else
            {
                isTriggerHeld = true;
                ButtonDownEvent.Invoke();
            }

        }
        else
        {
            ButtonUpEvent.Invoke();
            isTriggerHeld = false;
        }
    }
}
