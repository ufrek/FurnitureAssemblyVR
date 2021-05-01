using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

//Allows for teleportation on button press
public class Jumper : MonoBehaviour
{
    public XRNode inputSource;
    public Transform theCube;

    [SerializeField]
    private TeleportationProvider teleportationProvider;
    [SerializeField]
    private bool isTrigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.triggerButton, out isTrigger);

        if (isTrigger)
            Jump();
    }

    private void Jump()
    {
        var teleportRequest = new TeleportRequest();
        teleportRequest.destinationPosition = theCube.position;
        teleportationProvider.QueueTeleportRequest(teleportRequest);
    }
}
