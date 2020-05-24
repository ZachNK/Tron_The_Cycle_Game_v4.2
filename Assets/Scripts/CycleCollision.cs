using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleCollision : MonoBehaviour
{
    // Declared variable 'user' as UserControl
    public UserControl user;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Light"))
        {
            //Transfer collision (isCollide==true) message to UserControl script
            user.GetComponent<UserControl>().isCollide = true;
        }
    }
}