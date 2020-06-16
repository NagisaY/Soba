using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public Text scoreCountText;
    public Text timerText;
    public Text timeUpText;
    public float timer;
    int resultScore = PlayerController.getEatCount();
    private AudioSource sound01;

    // Start is called before the first frame update
    void Start()
    {
        timer = 30;
        AudioSource audioSource = GetComponent<AudioSource>();
        sound01 = audioSource;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer);
        scoreCountText.text = playerController.scoreCount.ToString() + " はい";
        if(playerController.isPlaying == true)
        {
            timer -= Time.deltaTime;
        }
        //Debug.Log(timer);
        timerText.text = "のこりじかん  " + timer.ToString("f0");

        if(timer <= 0)
        {
            if(timer > -0.01)
            {
                sound01.PlayOneShot(sound01.clip);

            }
            timeUpText.gameObject.SetActive(true);
            timerText.text = "のこり時間  0";

            if (timer <= -2.5f)
            {
                SceneManager.LoadScene("ResultScene");
            }

        }
    }
}
