using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SEController : MonoBehaviour
{
    int counter = 0;
    private AudioSource sound01;
    private AudioSource sound02;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && counter == 0)
        {
            counter++;
            Debug.Log("anyKeyDown");
            sound01.PlayOneShot(sound01.clip);
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 1)
        {
            counter++;
            sound02.PlayOneShot(sound02.clip);
            SceneManager.LoadScene("MainScene");
        }
    }
}
