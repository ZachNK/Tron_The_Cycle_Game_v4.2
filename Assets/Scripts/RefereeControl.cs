using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RefereeControl : MonoBehaviour
{
    // Declared variable 'user' as UserControl
    public GameObject user;

    // Declared variable 'rinzler' as RinzlerControl
    public GameObject rinzler;

    //Game Over Panel
    public GameObject gameLose;

    public GameObject gameWin;

    //Left and Right button UI
    public Button lbtn;

    public Button rbtn;

    // mini Map
    public RawImage miniMap;

    public bool isUserCrashed;

    public bool isRinzlerCrashed;

    // Start is called before the first frame update
    private void Start()
    {
        // a 'main' variable in CycleCollision and RinzlerCollision script is this script.
        user.GetComponent<UserControl>().referee = this;
        rinzler.GetComponent<RinzlerControl>().referee = this;

        isUserCrashed = false;
        isRinzlerCrashed = false;
        //Deactivate Game Lose panel
        gameLose.gameObject.SetActive(false);
        gameWin.gameObject.SetActive(false);

        //Activate left and right button
        lbtn.gameObject.SetActive(true);
        rbtn.gameObject.SetActive(true);

        //Activate mini map Raw image
        miniMap.GetComponent<RawImage>().gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isUserCrashed == true && isRinzlerCrashed == false)
        {
            // Hide buttons
            lbtn.gameObject.SetActive(false);
            rbtn.gameObject.SetActive(false);
            // Hide mini map
            miniMap.GetComponent<RawImage>().gameObject.SetActive(false);
            // Activate Game Lose Object
            gameLose.gameObject.SetActive(true);
            gameWin.gameObject.SetActive(false);
            //Transfer collision (isCollide==true) message to UserControl script
        }
        else if (isUserCrashed == false && isRinzlerCrashed == true)
        {
            // Hide buttons
            lbtn.gameObject.SetActive(false);
            rbtn.gameObject.SetActive(false);
            // Hide mini map
            miniMap.GetComponent<RawImage>().gameObject.SetActive(false);
            // Activate Game Win Object
            gameLose.gameObject.SetActive(false);
            gameWin.gameObject.SetActive(true);
            //Transfer collision (isCollide==true) message to UserControl script
        }
    }

    // private Scene load private to restart

    public void ReStart()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Exit Game
    public void ExitGame()
    {
        Application.Quit();
    }
}