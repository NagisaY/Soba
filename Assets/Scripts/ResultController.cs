﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    public Text resultScoreText;
    public Text banzukeText;
    int resultScore = PlayerController.getEatCount();

    private AudioSource sound01;
    private AudioSource sound02;
    private AudioSource sound03;
    private AudioSource sound04;
    bool loadResult = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
        sound03 = audioSources[2];
        sound04 = audioSources[3];
    }

    // Update is called once per frame
    void Update()
    {
        if(loadResult == false)
        {
            loadResult = true;
            resultScoreText.text = resultScore.ToString() + " はい";
            if (resultScore >= 30)
            {
                banzukeText.text = "横綱級！";
                sound01.PlayOneShot(sound01.clip);
                sound02.PlayOneShot(sound02.clip);
                sound03.PlayOneShot(sound03.clip);

            }
            else if (resultScore >= 25 && resultScore < 30)
            {
                banzukeText.text = "大関級！";
                sound02.PlayOneShot(sound02.clip);
            }
            else if (resultScore >= 15 && resultScore < 25)
            {
                banzukeText.text = "関脇級！";
                sound03.PlayOneShot(sound03.clip);
            }
            else
            {
                banzukeText.text = "小結級";
                sound04.PlayOneShot(sound04.clip);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene");   
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
        //MEMO	横綱	大関 関脇 小結
    }
}
