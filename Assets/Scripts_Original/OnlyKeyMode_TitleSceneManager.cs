using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnlyKeyMode_TitleSceneManager : MonoBehaviour
{
    public int counter = 0;
    public Image ruleImage;
    public Image rightKey;
    public Image leftKey;
    public Image spaceKey;
    public GameObject intro1;
    public GameObject intro2;
    //public GameObject intro3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //intro0→1枚目
        if (Input.anyKeyDown && counter == 0)
        {
            counter++;
            Debug.Log("anyKeyDown");
            ruleImage.gameObject.SetActive(true);
        }
        //intro1→2枚目
        else if(Input.GetKeyUp(KeyCode.RightArrow) && counter == 1)
        {
            //if (Input.GetKeyUp(KeyCode.RightArrow) && counter == 1)
            //{
                counter++;
                Debug.Log("rightKey1->2");
            //}

            //else if (Input.GetKeyUp(KeyCode.LeftArrow) && counter == 3)
            //{
            //    counter--;
            //    Debug.Log("leftKey2->1");
            //}
            intro1.gameObject.SetActive(false);
            intro2.gameObject.SetActive(true);
            //intro3.gameObject.SetActive(false);
            leftKey.gameObject.SetActive(true);
            rightKey.gameObject.SetActive(false);
            spaceKey.gameObject.SetActive(true);
        }
        //intro2→1枚目
        else if (Input.GetKeyUp(KeyCode.LeftArrow) && counter == 2)
        {
            counter--;
            Debug.Log("leftKey2->1");
            intro1.gameObject.SetActive(true);
            intro2.gameObject.SetActive(false);
            leftKey.gameObject.SetActive(false);
            rightKey.gameObject.SetActive(true);

        }
        ////intro2→3枚目
        //else if (Input.GetKeyDown(KeyCode.RightArrow) && counter == 2)
        //{
        //    counter++;
        //    Debug.Log("rightKey2->3");
        //    intro2.gameObject.SetActive(false);
        //    intro3.gameObject.SetActive(true);
        //    rightKey.gameObject.SetActive(false);
        //    spaceKey.gameObject.SetActive(true);

        //}

    }
}


//MEMO
//直すところ
//ResultControllerのロードするシーン名
//PlayerControllerの最初に押すキーの設定
//  space→Kに戻す,JoyConMode遷移戻す