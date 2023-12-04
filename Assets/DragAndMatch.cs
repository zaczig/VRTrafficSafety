using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DragAndMatch : MonoBehaviour
{

    public GameObject A1, A2, A3, A4, A5;
    public GameObject B1, B2, B3, B4, B5;
    public GameObject Q3;
    public GameObject Q3re;
    private TestControllerManager myTestManager;
    public Material red;
    public Material green;

    public AudioClip correct;
    public AudioClip wrong;
    public AudioSource source;
    Vector2 Pos1l, Pos2l, Pos3l, Pos4l, Pos5l;  // Store the initial position of A1.

    bool A1C, A2C, A3C, A4C, A5C = false;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        Pos1l = A1.transform.position;  // Store the initial position of A1.
        Pos2l = A2.transform.position;  // Store the initial localPosition of A1.
        Pos3l = A3.transform.position;  // Store the initial localPosition of A1.
        Pos4l = A4.transform.position;  // Store the initial localPosition of A1.
        Pos5l = A5.transform.position;  // Store the initial localPosition of A1.

        GameObject TestManager = GameObject.Find("TestController");
        myTestManager = TestManager.GetComponent<TestControllerManager>();

        source.Play();
    }


    // This method is automatically called when the object is released.
    public void SnaptoAns1()
    {
        // You can add any logic you need when the object is released here.
        float Distance = Vector2.Distance(A1.transform.position, B1.transform.position);
        

        if (Distance < 0.2f)
        {
            A1.transform.position = B1.transform.position;
            source.clip = correct;
            source.Play();
            A1C = true;
            A1.GetComponent<MeshRenderer>().material = green;
        }
        else
        {
            A1.transform.localPosition = Pos1l;
            source.clip = wrong;
            source.Play();
            A1.GetComponent<MeshRenderer>().material = red;

            // A1C = false;

        }
    }
    public void SnaptoAns2()
    {
        // You can add any logic you need when the object is released here.
        float Distance = Vector2.Distance(A2.transform.position, B2.transform.position);


        if (Distance < 0.2f)
        {
            A2.transform.position = B2.transform.position;
            source.clip = correct;
            source.Play();
            A2C = true;
            A2.GetComponent<MeshRenderer>().material = green;

        }
        else
        {
            A2.transform.localPosition = Pos2l;
            source.clip = wrong;
            source.Play();
            A2.GetComponent<MeshRenderer>().material = red;

            //A2C = false;
        }
    }
    public void SnaptoAns3()
    {
        // You can add any logic you need when the object is released here.
        float Distance = Vector2.Distance(A3.transform.position, B3.transform.position);


        if (Distance < 0.2f)
        {
            A3.transform.position = B3.transform.position;
            source.clip = correct;
            source.Play();
            A3C= true;
            A3.GetComponent<MeshRenderer>().material = green;

        }
        else
        {
            A3.transform.localPosition = Pos3l;
            source.clip = wrong;
            source.Play();
            //A3C = false;
            A3.GetComponent<MeshRenderer>().material = red;

        }
    }
    public void SnaptoAns4()
    {
        // You can add any logic you need when the object is released here.
        float Distance = Vector2.Distance(A4.transform.position, B4.transform.position);


        if (Distance < 0.2f)
        {
            A4.transform.position = B4.transform.position;
            source.clip = correct;
            source.Play();
            A4C = true;
            A4.GetComponent<MeshRenderer>().material = green;

        }
        else
        {
            A4.transform.localPosition = Pos4l;
            source.clip = wrong;
            source.Play();
            //A4C = false;
            A4.GetComponent<MeshRenderer>().material = red;

        }
    }

    public void SnaptoAns5()
    {
        // You can add any logic you need when the object is released here.
        float Distance = Vector2.Distance(A5.transform.position, B5.transform.position);


        if (Distance < 0.2f)
        {
            A5.transform.position = B5.transform.position;
            source.clip = correct;
            source.Play();
            A5C = true;
            A5.GetComponent<MeshRenderer>().material = green;


        }
        else
        {
            A5.transform.localPosition = Pos5l;
            source.clip = wrong;
            source.Play();
            //A5C = false;
            A5.GetComponent<MeshRenderer>().material = red;

        }
    }

    public void Quiz3isCorrect()
    {
        if (A1.GetComponent<MeshRenderer>().material == green &&
           A2.GetComponent<MeshRenderer>().material == green &&
           A3.GetComponent<MeshRenderer>().material == green &&
           A4.GetComponent<MeshRenderer>().material == green &&
           A5.GetComponent<MeshRenderer>().material == green)
        {
            Q3.SetActive(false);
        }
    }


}
