using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroInitiate : MonoBehaviour
{
    private GameObject intro;

    // Start is called before the first frame update
    private void Start()
    {
        intro = GetComponent<GameObject>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}