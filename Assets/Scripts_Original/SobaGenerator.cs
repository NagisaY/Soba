using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SobaGenerator : MonoBehaviour
{
    public GameObject[] soba;
    //public GameObject soba;
    //public GameObject spicySoba;
    public GameManager gameManager;
    public PlayerController playerController;
    int number;
    bool start = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.timer < 0.0f){
            Destroy(this.gameObject);
        }
        if(start == false && playerController.isPlaying == true)
        {
            InvokeRepeating("SobaGenRight", number, 0.9f);
            InvokeRepeating("SobaGenLeft", number, 0.9f);
            start = true;
        }
    }

    void SobaGenRight()
    {
        number = Random.Range(0, soba.Length);
        float pos_y = Random.Range(6.5f,12.5f); 
        Instantiate(soba[number], new Vector3(5.2f, pos_y, 0.0f), Quaternion.identity);

    }

    void SobaGenLeft()
    {
        number = Random.Range(0, soba.Length);
        float pos_y = Random.Range(6.5f, 12.5f);
        Instantiate(soba[number], new Vector3(-5.0f, pos_y, 0.0f), Quaternion.identity);

    }
}
