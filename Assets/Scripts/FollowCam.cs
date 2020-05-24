using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public UserControl control;
    public float dist;
    public float height;
    public float smoothRotate;

    private Transform cam;
    private Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        target = control.GetComponent<UserControl>().cycleInstance.transform;
        cam = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        float currentYAngle = Mathf.LerpAngle(cam.eulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, currentYAngle, 0);

        cam.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);

        cam.LookAt(target);
    }
}