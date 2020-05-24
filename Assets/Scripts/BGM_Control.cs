using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Control : MonoBehaviour
{
    public int numSound = 3;
    public AudioClip[] bgm_music;

    //public GameControl control;
    //public UserControl control;

    private AudioSource soundSource;

    // Start is called before the first frame update
    private void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        StartCoroutine("Playlist");
    }

    private IEnumerator Playlist()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!soundSource.isPlaying)
            {
                for (int i = 0; i < numSound; i++)
                {
                    soundSource.clip = bgm_music[i];
                    soundSource.Play();
                }

                soundSource.loop = true;
            }
        }
    }
}