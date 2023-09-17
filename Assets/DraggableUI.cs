using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DraggableUI : XRGrabInteractable
{
    public Transform snapPosition; // The position to snap to when released.
    private Vector3 initialPosition;
    private bool isDragging = false;
    private XRBaseInteractor interactor;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        initialPosition = transform.position;
        isDragging = true;
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        isDragging = false;

        // Snap to the specified position when released.
        if (snapPosition != null)
        {
            transform.position = snapPosition.position;
        }
        else
        {
            transform.position = initialPosition; // Return to the initial position if no snap position is defined.
        }
    }

    private void Update()
    {
        if (isDragging)
        {
            // Update the position of the draggable UI element while it's being dragged.
            Vector3 newPosition = transform.position;
            newPosition.x += interactor.transform.localPosition.x;
            newPosition.y += interactor.transform.localPosition.y;
            newPosition.z += interactor.transform.localPosition.z;
            transform.position = newPosition;
        }
    }
}
