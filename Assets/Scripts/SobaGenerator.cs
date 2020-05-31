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

    // Start is called before the first frame update
    void Start()
    {
        int number = Random.Range(3,5);
        int number_2 = Random.Range(3, 5);

        InvokeRepeating("SobaGenRight", number, 0.9f);
        InvokeRepeating("SobaGenLeft", number, 0.9f);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.timer < 0.0f){
            Destroy(this.gameObject);
        }
        
    }

    void SobaGenRight()
    {
        int number = Random.Range(0, soba.Length);
        float pos_y = Random.Range(6.5f,12.5f); 
        Instantiate(soba[number], new Vector3(5.0f, pos_y, 0.0f), Quaternion.identity);

    }

    void SobaGenLeft()
    {
        int number = Random.Range(0, soba.Length);
        float pos_y = Random.Range(6.5f, 12.5f);
        Instantiate(soba[number], new Vector3(-5.0f, pos_y, 0.0f), Quaternion.identity);

    }

    //MEMO
    //ランダム生成実装
}
