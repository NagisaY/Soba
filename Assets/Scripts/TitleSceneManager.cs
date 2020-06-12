using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    int counter = 0;
    public Image ruleImage;
    public Image introductionImage1;
    public GameObject karai;
    public GameObject manpuku;
    public Image maru1;
    public Image maru2;
    public Image maru3;
    public Image rightKey;
    public Image spaceKey;
    public Text introduction1;
    public Text introduction2;
    public Text introduction3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && counter == 0)
        {
            counter++;
            Debug.Log("anyKeyDown");
            ruleImage.gameObject.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) && counter == 1)
        {
            counter++;
            Debug.Log("rightKey1");
            introductionImage1.gameObject.SetActive(false);
            maru1.gameObject.SetActive(false);
            maru2.gameObject.SetActive(true);
            rightKey.gameObject.SetActive(false);
            spaceKey.gameObject.SetActive(true);
            introduction1.gameObject.SetActive(false);
            introduction2.gameObject.SetActive(true);
            karai.gameObject.SetActive(true);
            manpuku.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 2)
        {
            SceneManager.LoadScene("MainScene");
        }

        //できればもうひと画面作る
        //if (Input.GetKeyUp(KeyCode.S) && counter == 2)
        //{
        //    counter++;
        //    Debug.Log("rightKey2");
        //    introductionImage1.gameObject.SetActive(false);
        //    maru2.gameObject.SetActive(false);
        //    maru3.gameObject.SetActive(true);
        //    introduction2.gameObject.SetActive(false);
        //    introduction3.gameObject.SetActive(true);
        //    karai.gameObject.SetActive(false);
        //    manpuku.gameObject.SetActive(false);
        //}
        //if (Input.GetKeyDown(KeyCode.Space) && counter == 3)
        //{
        //    counter++;
        //    SceneManager.LoadScene("MainScene");
        //    maru1.gameObject.SetActive(false);
        //    maru2.gameObject.SetActive(true);
        //    introduction1.gameObject.SetActive(false);
        //    introduction2.gameObject.SetActive(true);
        //}
        //if (Input.GetKeyDown(KeyCode.Space) && counter == 4)
        //{
        //    SceneManager.LoadScene("MainScene");
        //}
    }
}
