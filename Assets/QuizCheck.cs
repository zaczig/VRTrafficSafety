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
    public Material green;


    public void Quiz3isCorrect()
    {
        print("Check");
        print(A1.GetComponent<Renderer>());
        if (A1.GetComponent<Renderer>() == green &&
           A2.GetComponent<Renderer>() == green &&
           A3.GetComponent<Renderer>() == green &&
           A4.GetComponent<Renderer>() == green &&
           A5.GetComponent<Renderer>() == green)
        {
            print("Complete");
            Quiz.SetActive(false);
        }
    }

}
