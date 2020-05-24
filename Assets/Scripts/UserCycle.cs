using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCycle : MonoBehaviour
{
    public GameObject lightWall;

    private void Update()
    {
    }

    public void SpinUser()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
        }
    }

    public void SpawnLight()
    {
    }
}