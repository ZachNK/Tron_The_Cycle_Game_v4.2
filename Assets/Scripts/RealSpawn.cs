using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealSpawn : MonoBehaviour
{
    // light wall prefab
    public GameObject lightSource;

    public UserControl control;

    private GameObject realWall;

    //Button
    public Button lbtn;

    public Button rbtn;

    // instance light wall start position
    private Vector3 startPoint;

    // instace light wall start angle
    private Quaternion startAngle;

    private bool isLClick;
    private bool isRClick;

    private int num;

    //position check
    private float x = 0, z = 0;

    private float px = 0, pz = 0;

    // Start is called before the first frame update
    private void Start()
    {
        num = 0;

        startPoint = new Vector3(20.0f, 0.0f, 20.0f);

        startAngle = Quaternion.identity;
        realWall = (GameObject)Instantiate(lightSource, startPoint, startAngle);
        isLClick = lbtn.GetComponent<ButtonCall>().isClick;
        isRClick = rbtn.GetComponent<ButtonCall>().isClick;
        x = startPoint.x;
        z = startPoint.z;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public int CountNum()
    {
        if (isLClick == true || isRClick == true)
        {
            num++;
        }
        return num;
    }

    public void RealSpawnWall()
    {
        px = x; pz = z;
        Vector3 pastVector = new Vector3(px, 0.0f, pz);
        startAngle = control.GetComponent<UserControl>().cycleInstance.transform.rotation;
        x = control.GetComponent<UserControl>().cycleInstance.transform.position.x;
        z = control.GetComponent<UserControl>().cycleInstance.transform.position.z;
        Vector3 newVector = new Vector3(x, 0.0f, z);
        float dist = Vector3.Distance(newVector, pastVector);
        realWall = (GameObject)Instantiate(lightSource, pastVector, startAngle);
        realWall.transform.localScale += new Vector3(10 * dist, 0.0f, 0.0f);
        //odd-->dz
        //if (CountNum() % 2 != 0)
        //{
        //    realWall.transform.localScale = new Vector3(1.0f, 1.0f, dist);
        //    Debug.Log("real odd: " + x + ", " + px + ", " + z + ", " + pz);
        //}
        ////even-->dx
        //else if (CountNum() % 2 == 0)
        //{
        //    //realWall.transform.localScale = new Vector3(10 * (x - px), 1.0f, 1.0f);
        //    realWall.transform.localScale = new Vector3(dist, 1.0f, 1.0f);
        //    Debug.Log("real odd: " + x + ", " + px + ", " + z + ", " + pz);
        //}
    }
}