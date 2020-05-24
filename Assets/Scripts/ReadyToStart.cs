using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyToStart : MonoBehaviour
{
    public Text counting;
    public GameObject controlPanel;

    public FollowCam cam;
    public GameObject lbtn;
    public GameObject rbtn;

    private float time;

    public void Start()
    {
        controlPanel.SetActive(false);
        cam.GetComponent<FollowCam>().gameObject.SetActive(false);
        lbtn.gameObject.SetActive(false);
        rbtn.gameObject.SetActive(false);
        time = 0;
    }

    public void Update()
    {
        time += Time.deltaTime;
        CountNum();
    }

    public void CountNum()
    {
        if (time >= 0.0f && time < 1.0f)
        {
            counting.text = "1";
        }
        else if (time >= 1.0f && time < 2.0f)
        {
            counting.text = "2";
        }
        else if (time >= 2.0f && time < 3.0f)
        {
            counting.text = "3";
        }
        else if (time >= 3.0f)
        {
            counting.text = "GO";
            controlPanel.SetActive(true);
            cam.GetComponent<FollowCam>().gameObject.SetActive(true);
            lbtn.gameObject.SetActive(true);
            rbtn.gameObject.SetActive(true);
            counting.gameObject.SetActive(false);
        }
    }
}