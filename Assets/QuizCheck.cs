using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizCheck : MonoBehaviour
{
    public GameObject A1;  // Reference to the draggable object A1.
    public GameObject B1;  // Reference to the drop target B1.
    public GameObject A2;  // Reference to the draggable object A1.
    public GameObject B2;  // Reference to the drop target B1.
    public GameObject A3;  // Reference to the draggable object A1.
    public GameObject B3;  // Reference to the drop target B1.
    public GameObject A4;  // Reference to the draggable object A1.
    public GameObject B4;  // Reference to the drop target B1.
    public GameObject A5;  // Reference to the draggable object A1.
    public GameObject B5;  // Reference to the drop target B1.

    public GameObject Quiz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Quiz3isCorrect()
    {
        if (A1.transform.position == B1.transform.position &&
           A2.transform.position == B2.transform.position &&
           A3.transform.position == B3.transform.position &&
           A4.transform.position == B4.transform.position &&
           A5.transform.position == B5.transform.position)
        {
            Quiz.SetActive(false);
        }
    }

}
