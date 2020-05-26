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


    // Start is called before the first frame update
    void Start()
    {
        timer = 20;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCountText.text = playerController.scoreCount.ToString() + " はい";
        timer -= Time.deltaTime;
        //Debug.Log(timer);
        timerText.text = "のこり時間  " + timer.ToString("f0");

        if(timer <= 0)
        {
            timeUpText.gameObject.SetActive(true);
            timerText.text = "のこり時間  0";


            if (timer <= -2.5f)
            {
                SceneManager.LoadScene("ResultScene");
            }

        }
    }
}
