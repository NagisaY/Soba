using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    int counter = 0;
    public GameObject ruleImage;

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
        if (Input.GetKeyDown(KeyCode.Space) && counter == 1)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
