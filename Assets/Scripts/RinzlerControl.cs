using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RinzlerControl : MonoBehaviour
{
    // Referee Control for isCollide message
    public RefereeControl referee;

    //To Track the position of user
    public Transform userPivot;

    // cycle Prefab
    public GameObject rinzlerPrefab;

    // For cycle Following Camera
    public GameObject rinzlerInstance;

    // light wall prefab
    public GameObject lightSourceRinzler;

    // instance light wall
    private GameObject instanceWallRinzler;

    //Left and Right button UI
    public Button lbtn;

    public Button rbtn;

    // Rinzler Speed
    public float rinzlerSpeed = 0.0f;

    //Rinzler Collision Check
    public bool isRinzlerCollide;

    //Rinzler Running Check
    public bool isRinzlerRunning;

    // instance light wall start position
    private Vector3 startPointRinzler;

    // instace light wall start angle
    private Quaternion startAngleRinzler;

    // Start Game Check
    private float time;

    //checking wheather button clicked
    private int rinzlerLClick = 0;

    private int rinzlerRClick = 0;

    //Rinzler click num
    private int num = 0;

    // Start is called before the first frame update
    private void Start()
    {
        time = 0;
        isRinzlerCollide = false;
        isRinzlerRunning = false;

        // Initial position of instance cycle
        startPointRinzler = new Vector3(480.0f, 0.0f, 20.0f);

        // Initial angle of instance cycle
        startAngleRinzler = Quaternion.identity;
        // Instantiate Rinzler cycle
        rinzlerInstance = (GameObject)Instantiate(rinzlerPrefab, startPointRinzler, startAngleRinzler);
        // Instantiate Rinzler light wall
        instanceWallRinzler = (GameObject)Instantiate(lightSourceRinzler, startPointRinzler, startAngleRinzler);

        rinzlerInstance.GetComponent<RinzlerCollision>().rinzler = this;
        referee.GetComponent<RefereeControl>().isRinzlerCrashed = false;

        rinzlerLClick = lbtn.GetComponent<ButtonCall>().num;
        rinzlerRClick = rbtn.GetComponent<ButtonCall>().num;
    }

    // Update is called once per frame
    private void Update()
    {
        // if it's over 4 seconds,
        if (time > 4.0f)
        {
            // Activate Running checker
            isRinzlerRunning = true;
        }

        if (isRinzlerRunning == true && isRinzlerCollide == false)
        {
            RunRinzler(0.5f);
        }
        else if (isRinzlerRunning == false && isRinzlerCollide == true)
        {
            RunRinzler(0.0f);
        }

        // if rinzler cycle collides any object,
        if (isRinzlerCollide == true)
        {
            referee.GetComponent<RefereeControl>().isRinzlerCrashed = true;
            // Deactivate running checker
            RunRinzler(0.0f);
        }

        time += Time.deltaTime;
    }

    // Left Button Function
    public void RinzlerTurnLeft()
    {
        // Rotate cycle
        rinzlerInstance.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));

        // New cycle position and angle
        startPointRinzler = rinzlerInstance.transform.position;
        startAngleRinzler = rinzlerInstance.transform.rotation;

        // Apply the new position and angle to spawning instance wall
        SpawnWallRinzler(startPointRinzler, startAngleRinzler);
    }

    // Right Button Function
    public void RinzlerTurnRight()
    {
        // Rotate cycle
        rinzlerInstance.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));

        // New cycle position and angle
        startPointRinzler = rinzlerInstance.transform.position;
        startAngleRinzler = rinzlerInstance.transform.rotation;

        // Apply the new position and angle to spawning instance wall
        SpawnWallRinzler(startPointRinzler, startAngleRinzler);
    }

    // Cycle running function
    public void RunRinzler(float x)
    {
        // Make cycle run on its speed
        rinzlerInstance.transform.Translate(new Vector3(0.0f, 0.0f, x));

        // Make light wall expand its body at speed x 9.89 (constance value)
        instanceWallRinzler.transform.localScale += new Vector3(0.0f, 0.0f, x * 9.98f);
    }

    //Spawn instance wall
    public GameObject SpawnWallRinzler(Vector3 start, Quaternion angle)
    {
        // Make light wall instantiate
        instanceWallRinzler = (GameObject)Instantiate(lightSourceRinzler, start, angle);
        // return new light wall
        return instanceWallRinzler;
    }

    public void RinzlerMethod()
    {
        if (rinzlerLClick != 0 || rinzlerRClick != 0)
        {
            num++;
        }
        if (num % 2 != 0)
        {
            if (rinzlerInstance.transform.position.z > userPivot.transform.position.z)
            {
                RinzlerTurnLeft();
            }
            else if (rinzlerInstance.transform.position.z < userPivot.transform.position.z)
            {
                RinzlerTurnRight();
            }
            else if (rinzlerInstance.transform.position.z == userPivot.transform.position.z)
            {
                if (rinzlerInstance.transform.position.z - 250f >= 0f)
                {
                    RinzlerTurnLeft();
                }
                else if (rinzlerInstance.transform.position.z - 250f < 0f)
                {
                    RinzlerTurnRight();
                }
            }
        }
        else if (num % 2 == 0)
        {
            if (rinzlerInstance.transform.position.x > userPivot.transform.position.x)
            {
                RinzlerTurnLeft();
            }
            else if (rinzlerInstance.transform.position.x < userPivot.transform.position.x)
            {
                RinzlerTurnRight();
            }
            else if (rinzlerInstance.transform.position.x == userPivot.transform.position.x)
            {
                if (rinzlerInstance.transform.position.x - 250f >= 0f)
                {
                    RinzlerTurnLeft();
                }
                else if (rinzlerInstance.transform.position.x - 250f < 0f)
                {
                    RinzlerTurnRight();
                }
            }
        }
    }
}