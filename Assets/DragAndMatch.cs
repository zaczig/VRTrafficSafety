using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DragAndMatch : MonoBehaviour
{
    public GameObject A1;  // Reference to the draggable object A1.
    public GameObject B1;  // Reference to the drop target B1.
    public AudioClip correct;
    public AudioClip wrong;
    private AudioSource source;
    private Vector3 Pos1;  // Store the initial position of A1.
    private bool A1C;     // Flag to track whether A1 is correctly matched.

    private void Start()
    {
        source = GetComponent<AudioSource>();
        Pos1 = A1.transform.position;  // Store the initial position of A1.
    }

    // The XR Grab Interactable component will handle the dragging for you.
    // You can attach this script to A1.

    // This method is automatically called when the object is grabbed.
    public void OnSelectEnter(XRBaseInteractor interactor)
    {
        // You can add any logic you need when the object is grabbed here.
        A1.transform.position = interactor.transform.position;

    }

    // This method is automatically called when the object is released.
    public void OnSelectExit(XRBaseInteractor interactor)
    {
        // You can add any logic you need when the object is released here.
        float Distance = Vector2.Distance(A1.transform.position, B1.transform.position);
        if (Distance < 700)
        {
            A1.transform.position = B1.transform.position;
            source.clip = correct;
            source.Play();
            A1C = true;
        }
        else
        {
            A1.transform.position = Pos1;
            source.clip = wrong;
            source.Play();
        }
    }

    // This method is automatically called while the object is being moved.
    public void OnSelectStay(XRBaseInteractor interactor)
    {
        // Update the position of A1 to match the controller's position.
        A1.transform.position = interactor.transform.position;
    }

    // You can use this method to check for a successful match when the object is dropped.
    public void OnSelectDeselect(XRBaseInteractor interactor)
    {
        float Distance = Vector2.Distance(A1.transform.position, B1.transform.position);
        if (Distance < 700)
        {
            A1.transform.position = B1.transform.position;
            source.clip = correct;
            source.Play();
            A1C = true;
        }
        else
        {
            A1.transform.position = Pos1;
            source.clip = wrong;
            source.Play();
        }
    }
}
