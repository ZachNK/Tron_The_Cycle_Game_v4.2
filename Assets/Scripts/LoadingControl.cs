using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingControl : MonoBehaviour
{
    private AsyncOperation ao;

    public Slider progressBar;
    public Text loadingText;

    // Start is called before the first frame update
    private void Start()
    {
        progressBar.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
        loadingText.text = "Loading...";
        StartCoroutine(LoadingScene());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public IEnumerator LoadingScene()
    {
        yield return new WaitForSeconds(1);
        ao = SceneManager.LoadSceneAsync(1);
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            progressBar.value = ao.progress;
            if (ao.progress == 0.9f)
            {
                progressBar.value = 1f;
                loadingText.text = "Press to Start";
            }

            yield return null;
        }
    }

    public void PressToStartButton()
    {
        ao.allowSceneActivation = true;
    }
}