using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerScript : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
	[SerializeField] Transform wheel1;
	[SerializeField] Transform wheel2;
	
	[SerializeField] public float movementSpeed = 1.0f;
	[SerializeField] float rotateSpeed = 1.0f;
	[SerializeField] private Vector3 TurnSpeed;

	public int currentTargetPos;

    private List<Transform> WayPoints;
	public ButtonManager buttonManager;

	public GameObject quiz2;
	public GameObject quiz3;
	public GameObject quiz4;
    public GameObject qre4;
    public GameObject quiz5;
	public GameObject quiz6;
	public GameObject quiz7;

    public GameObject chain;

	public bool hasCrossed = false;
    public bool fulfilledTest = false;
    public bool startTest = false;

    private UITaskController myUIController;
    [SerializeField] private GameObject FinalUI;

    private bool experienceDone = false;
    private int degresPerSecond = 2;
    public float bikeMovement = 1.0f;
    public GameObject playing;

    private BlinkWarningController myWarningController;

    private CarSpeedController mySpeedController1;
    private CarSpeedController mySpeedController2;
    private CarSpeedController mySpeedController3;
    private CarSpeedController mySpeedController4;

    [SerializeField] private GameObject PostBrakeLights;
    [SerializeField] private GameObject PostBackLights;

    // Start is called before the first frame update
    void Start()
    {
        setStartTestFalse();

        //chain.SetActive(false);
        WayPoints = new List<Transform>();
        WayPoints.Add(GameObject.Find("WayPoint2").transform);
        WayPoints.Add(GameObject.Find("WayPoint3").transform);
        WayPoints.Add(GameObject.Find("WayPoint4").transform);
        WayPoints.Add(GameObject.Find("WayPoint5").transform);
        WayPoints.Add(GameObject.Find("WayPoint6").transform);
		WayPoints.Add(GameObject.Find("WayPoint7").transform);
		WayPoints.Add(GameObject.Find("WayPoint8").transform);
		WayPoints.Add(GameObject.Find("WayPoint9").transform);
		WayPoints.Add(GameObject.Find("WayPoint10").transform);
		WayPoints.Add(GameObject.Find("WayPoint11").transform);
        WayPoints.Add(GameObject.Find("WayPoint12").transform);
        WayPoints.Add(GameObject.Find("WayPoint13").transform);
        WayPoints.Add(GameObject.Find("WayPoint14").transform);
        WayPoints.Add(GameObject.Find("WayPoint15").transform);
        WayPoints.Add(GameObject.Find("WayPoint16").transform);
        WayPoints.Add(GameObject.Find("WayPoint17").transform);
        WayPoints.Add(GameObject.Find("WayPoint18").transform);
        WayPoints.Add(GameObject.Find("WayPoint19").transform);
        WayPoints.Add(GameObject.Find("WayPoint20").transform);
        WayPoints.Add(GameObject.Find("WayPoint21").transform);
        WayPoints.Add(GameObject.Find("WayPoint22").transform);
        WayPoints.Add(GameObject.Find("WayPoint23").transform);
        WayPoints.Add(GameObject.Find("WayPoint24").transform);

        currentTargetPos = 0;

        GameObject WarningObject = GameObject.Find("WarningSymbols");
        myWarningController = WarningObject.GetComponent<BlinkWarningController>();

        GameObject SpeedObject1 = GameObject.Find("CarMovementController1");
        GameObject SpeedObject2 = GameObject.Find("CarMovementController2");
        GameObject SpeedObject3 = GameObject.Find("CarMovementController3");
        GameObject SpeedObject4 = GameObject.Find("CarMovementController4");
        mySpeedController1 = SpeedObject1.GetComponent<CarSpeedController>();
        mySpeedController2 = SpeedObject2.GetComponent<CarSpeedController>();
        mySpeedController3 = SpeedObject3.GetComponent<CarSpeedController>();
        mySpeedController4 = SpeedObject4.GetComponent<CarSpeedController>();

        //GameObject UIController = GameObject.Find("UI_Checklist");
        //myUIController = UIController.GetComponent<UITaskController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!experienceDone)
        {
            rotationRoutine();

            if (playing.activeInHierarchy)
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, WayPoints[currentTargetPos].position, movementSpeed * Time.deltaTime * bikeMovement);
            }
            else
            {
                playerTransform.position = Vector3.MoveTowards(playerTransform.position, WayPoints[currentTargetPos].position, movementSpeed * 0 * bikeMovement);

            }

            updateWheelRotate();

            updateTargetPosition();
        }  
    }


    private void rotationRoutine()
    {
        Vector3 directionFromMeToTarget = (playerTransform.position - WayPoints[currentTargetPos].position);

        directionFromMeToTarget.z = -1.0f * (directionFromMeToTarget.z);
        directionFromMeToTarget.y = 0.0f; //remove y component, as we will rotate around axis
        directionFromMeToTarget.x = Mathf.Abs(directionFromMeToTarget.x);
        if (currentTargetPos < 6)
        {
            Mathf.Abs(directionFromMeToTarget.x);
        }
        else
        {
            directionFromMeToTarget.x = -1.0f * (directionFromMeToTarget.x);
        }

        Quaternion lookRotation = Quaternion.LookRotation(directionFromMeToTarget);

        if (playing.activeInHierarchy)
        {
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, lookRotation, Time.deltaTime * degresPerSecond);

        }
        else
        {
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, lookRotation, 0 * degresPerSecond);

        }
    }

    void updateWheelRotate()
    {
		if (playerTransform.position != WayPoints[currentTargetPos].position)
		{
            if (playing.activeInHierarchy)
            {
                wheel1.Rotate(360 * rotateSpeed * Time.deltaTime * bikeMovement, 0, 0);
                wheel2.Rotate(360 * rotateSpeed * Time.deltaTime * bikeMovement, 0, 0);
            }
            else
            {
                wheel1.Rotate(360 * rotateSpeed * 0 * bikeMovement, 0, 0);
                wheel2.Rotate(360 * rotateSpeed * 0 * bikeMovement, 0, 0);
            }
			
		}
        
	}
    void updateTargetPosition()
    {
        if (playerTransform.position == WayPoints[currentTargetPos].position)
        {
			if (playerTransform.position == WayPoints[2].position)
			{
				//Time.timeScale = 0f;
                playing.SetActive(false);
				quiz2.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);
			}

			else if (playerTransform.position == WayPoints[6].position )
            {
                bikeMovement = 0.0f;
                //Time.timeScale = 0f;
                playing.SetActive(false);
                quiz3.SetActive(true);
                Invoke(nameof(timeContinue), 2.0f);

            }

            else if (playerTransform.position == WayPoints[8].position)
			{
                //Time.timeScale = 0f;
                playing.SetActive(false);
                quiz4.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);

			}

            else if (playerTransform.position == WayPoints[10].position)
            {
                //Time.timeScale = 0f;
                playing.SetActive(false);

                qre4.SetActive(true);
                Invoke(nameof(timeContinue), 2.0f);

            }

            else if (playerTransform.position == WayPoints[13].position)
			{
                //Time.timeScale = 0f;
                playing.SetActive(false);

                quiz5.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);


			}
            else if (playerTransform.position == WayPoints[16].position)
			{
                bikeMovement = 0.0f;
                mySpeedController1.slowingDown = true;
                mySpeedController2.slowingDown = true;
                //Time.timeScale = 0f;
                playing.SetActive(false);

                quiz6.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);

			}
            else if (playerTransform.position == WayPoints[20].position)
			{
                bikeMovement = 0.0f;
                //Time.timeScale = 0f;
                playing.SetActive(false);

                quiz7.SetActive(true);
				Invoke(nameof(timeContinue), 2.0f);


			}
			currentTargetPos++;
        }

        if (playerTransform.position == WayPoints[WayPoints.Count-1].position)
        {
            experienceDone = true;
            bikeMovement = 0.0f;
            //Time.timeScale = 0.0f;
            playing.SetActive(false);
            FinalUI.SetActive(true);
        }
    }

    public void setStartTestFalse()
    {
        startTest = false;
        fulfilledTest = true;      
    }

    public void bikeContinue()
    {
        bikeMovement = 1.0f;
        //Time.timeScale = 1f;
        playing.SetActive(true);


        if (playerTransform.position == WayPoints[16].position)
        {
            Invoke(nameof(resetCarsSpeed), 4.0f);
        }
    }

    private void resetCarsSpeed()
    {
        mySpeedController1.slowingDown = false;
        mySpeedController2.slowingDown = false;
        mySpeedController1.resetSpeed(false);
        mySpeedController2.resetSpeed(false);
        mySpeedController3.resetSpeed(false);
        mySpeedController4.resetSpeed(false);
    }

    public int getWaypointsLength()
    {
        return WayPoints.Count;
    }

    public bool getExperienceDone()
    {
        return experienceDone;
    }

    public void timeContinue()
    {
        //Time.timeScale = 1f;
        //playing.SetActive(true);

        if(playerTransform.position == WayPoints[6].position || playerTransform.position == WayPoints[16].position || playerTransform.position == WayPoints[20].position)
        {
            startTest = true;
        }

    }

    public void timeContinueWarning()
    {
        Time.timeScale = 1f;
        playing.SetActive(true);
        Invoke(nameof(callWarning), 3.0f);
    }

    private void callWarning()
    {
        myWarningController.playRightWarning();
    }

    public float getBikeMovement()
    {
        return bikeMovement;
    }
    public void changeCarLights()
    {
        if (PostBackLights != null)
        {
            PostBrakeLights.SetActive(true);
            PostBackLights.SetActive(false);
        }
    }
}
