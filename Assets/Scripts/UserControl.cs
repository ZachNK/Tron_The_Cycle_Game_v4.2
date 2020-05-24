using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserControl : MonoBehaviour
{
    // Referee Control for isCollide message
    public RefereeControl referee;

    public Transform userPivot;

    // cycle Prefab
    public GameObject cyclePrefab;

    // For cycle Following Camera
    public GameObject cycleInstance;

    // light wall prefab
    public GameObject lightSource;

    // instance light wall
    private GameObject instanceWall;

    //UIs

    //Left and Right button UI
    public Button lbtn;

    public Button rbtn;

    //declare public speed
    public float speed = 0.0f;

    // Control panel
    public bool isCollide;

    // Control cycle action
    public bool isRunning;

    // instance light wall start position
    private Vector3 startPoint;

    // instace light wall start angle
    private Quaternion startAngle;

    //checking wheather button clicked
    private bool isLClick;

    private bool isRClick;

    // Start Game Check
    private float time;

    // Start is called before the first frame update
    private void Start()
    {
        time = 0;
        isCollide = false;
        isRunning = false;

        //Object reference set to an instance of an object,

        // Initial position of instance cycle
        startPoint = new Vector3(20.0f, 0.0f, 20.0f);

        // Initial angle of instance cycle
        startAngle = Quaternion.identity;
        // Instantiate cycle
        cycleInstance = (GameObject)Instantiate(cyclePrefab, startPoint, startAngle);
        // Instantiate light wall
        instanceWall = (GameObject)Instantiate(lightSource, startPoint, startAngle);

        cycleInstance.GetComponent<CycleCollision>().user = this;
        referee.GetComponent<RefereeControl>().isUserCrashed = false;
        //Activate left and right button
        lbtn.gameObject.SetActive(true);
        rbtn.gameObject.SetActive(true);

        // checking button clicked
        isLClick = lbtn.GetComponent<ButtonCall>().isClick;
        isRClick = rbtn.GetComponent<ButtonCall>().isClick;
    }

    // Update is called once per frame
    private void Update()
    {
        // if it's over 4 seconds,
        if (time > 4.0f)
        {
            // Activate Running checker
            isRunning = true;
        }

        // if running checker activated, no click event of right and left buttons, and no collision event,
        if (isRunning == true && isCollide == false && isLClick == false && isRClick == false)
        {
            // Play RunCycle to user cycle to run
            RunCycle(speed);
        }

        // if user cycle collides any object,
        if (isCollide == true)
        {
            referee.GetComponent<RefereeControl>().isUserCrashed = true;
            // Deactivate running checker
            RunCycle(0.0f);
        }

        time += Time.deltaTime;
    }

    // Left Button Function
    public void TurnLeft()
    {
        //Destroy(instanceWall);

        // Stop to run
        //RunCycle(0f);

        // Rotate cycle
        cycleInstance.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
        userPivot.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
        // New cycle position and angle
        startPoint = cycleInstance.transform.position;
        startAngle = cycleInstance.transform.rotation;

        // Apply the new position and angle to spawning instance wall
        SpawnWall(startPoint, startAngle);
    }

    // Right Button Function
    public void TurnRight()
    {
        //Destroy(instanceWall);

        // Stop to run
        //RunCycle(0f);

        // Rotate cycle
        cycleInstance.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        userPivot.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        // New cycle position and angle
        startPoint = cycleInstance.transform.position;
        startAngle = cycleInstance.transform.rotation;

        // Apply the new position and angle to spawning instance wall
        SpawnWall(startPoint, startAngle);
    }

    // Cycle running function
    public void RunCycle(float x)
    {
        // Make cycle run on its speed
        cycleInstance.transform.Translate(new Vector3(0.0f, 0.0f, x));
        userPivot.transform.Translate(new Vector3(0.0f, 0.0f, x));
        // Make light wall expand its body at speed x 9.89 (constance value)
        instanceWall.transform.localScale += new Vector3(0.0f, 0.0f, x * 9.98f);
    }

    //Spawn instance wall
    public GameObject SpawnWall(Vector3 start, Quaternion angle)
    {
        // Make light wall instantiate
        instanceWall = (GameObject)Instantiate(lightSource, start, angle);
        // return new light wall
        return instanceWall;
    }
}