using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadBarScript : MonoBehaviour
{
    public Slider progressBar;
    public Text loadingText;

    public float fakeIncreement = 0f;
    public float fakeTiming = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        progressBar.gameObject.SetActive(true);

        loadingText.text = "Loading...";
        StartCoroutine(FakeProgress());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator FakeProgress()
    {
        yield return new WaitForSeconds(1);

        while (progressBar.value != 1f)
        {
            progressBar.value += fakeIncreement;
            yield return new WaitForSeconds(fakeTiming);
        }

        while (progressBar.value == 1f)
        {
            SceneManager.LoadScene(3);

            yield return null;
        }
    }
}