using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public Text resultScoreText;
    public Text banzukeText;
    int resultScore = PlayerController.getEatCount();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        resultScoreText.text = resultScore.ToString() + " はい";
        if (resultScore >= 20)
        {
            banzukeText.text = "横綱級！";
        }
        else if (resultScore >= 15 && resultScore < 20)
        {
            banzukeText.text = "大関級！";
        }
        else if (resultScore >= 10 && resultScore < 15)
        {
            banzukeText.text = "関脇級！";
        }
        else
        {
            banzukeText.text = "小結級";
        }

        //MEMO	横綱	大関 関脇 小結
}
}
