using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class TeleportTo : MonoBehaviour
{
    public InputHelpers.Button inputHelpers = InputHelpers.Button.MenuButton;
    public XRNode controller = XRNode.LeftHand;
    public GameObject XROrigin;
    public Vector3 targetPosition;
    public Quaternion targetRotation;
    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), inputHelpers, out bool isPressed);

        if (isPressed)
        {
            XROrigin.gameObject.transform.position = targetPosition;
            XROrigin.gameObject.transform.rotation = targetRotation;
        }
    }
}
