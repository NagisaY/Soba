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
        Debug.Log(counter);
        if (Input.anyKeyDown && counter == 0)
        {
            counter++;
            sound01.PlayOneShot(sound01.clip);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && (counter == 1 || counter == 2))
        {
            counter++;
            sound01.PlayOneShot(sound01.clip);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && (counter == 2 || counter == 3))
        {
            counter--;
            sound01.PlayOneShot(sound01.clip);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && counter == 3)
        {
            Debug.Log("dodon");
            sound02.PlayOneShot(sound02.clip);
            counter++;
            SceneManager.LoadScene("MainScene");
        }
    }
}
