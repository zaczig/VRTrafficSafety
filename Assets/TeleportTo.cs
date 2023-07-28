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
    public GameObject XROriginCtrl;
    public GameObject btnManager;
    public Vector3 targetPosition;
    public Quaternion targetRotation;
    public Vector3 targetcPosition;
    public Quaternion targetcRotation;
    public int count = 0;
    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(controller), inputHelpers, out bool isPressed);

        if (isPressed)
        {
            XROrigin.gameObject.transform.localPosition = targetPosition;
            XROrigin.gameObject.transform.localRotation = targetRotation;
            XROriginCtrl.gameObject.transform.position = targetcPosition;
            XROriginCtrl.gameObject.transform.rotation = targetcRotation;

/*            if(count == 0)
            {
                btnManager.GetComponent<ButtonManager>().begin();
                count++;
            }*/
        }
    }
}
