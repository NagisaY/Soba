using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleUIController : MonoBehaviour
{

    public Text startText;
    bool a_flag;
    float a_color;
    // Use this for initialization
    void Start()
    {
        a_flag = false;
        a_color = 1;
    }

    // Update is called once per frame
    void Update()
    {
        startText.color = new Color(1, 1, 1, a_color);

        //a_flagがtrueの間実行する
        if (a_flag == false)
        {
            //テキストの透明度を変更する
            a_color -= Time.deltaTime;
            //a_color--;
            if (a_color < 0)
            {
                a_flag = true;
            }
        }
        if (a_flag == true)
        {
            a_color += Time.deltaTime;
            //a_color++;
            if (a_color > 1)
            {
                a_flag = false;
            }
        }
    }
}