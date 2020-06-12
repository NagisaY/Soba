using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    public Text resultScoreText;
    public Text banzukeText;
    public GameObject osumousan;
    public GameObject owans_sekiwake;
    public GameObject owans_ozeki;
    public GameObject owans_yokozuna;

    int resultScore = PlayerController.getEatCount();

    private AudioSource sound01;
    private AudioSource sound02;
    private AudioSource sound03;
    private AudioSource sound04;
    bool loadResult = false;
    Vector3 yokozunaSize;
    Vector3 ozekiSize;
    Vector3 sekiwakeSize;
    Vector3 komusubiSize;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
        sound03 = audioSources[2];
        sound04 = audioSources[3];

        yokozunaSize = new Vector3(1.0f, 0.8f, 1.0f);
        ozekiSize = new Vector3(0.8f, 0.73f, 1.0f);
        sekiwakeSize = new Vector3(0.7f, 0.68f, 1.0f);
        komusubiSize = new Vector3(0.5f, 0.55f, 1.0f);
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
                owans_sekiwake.gameObject.SetActive(true);
                owans_ozeki.gameObject.SetActive(true);
                owans_yokozuna.gameObject.SetActive(true);
                osumousan.transform.localScale = yokozunaSize;
                sound01.PlayOneShot(sound01.clip);
                sound02.PlayOneShot(sound02.clip);
                sound03.PlayOneShot(sound03.clip);

            }
            else if (resultScore >= 25 && resultScore < 30)
            {
                owans_sekiwake.gameObject.SetActive(true);
                owans_ozeki.gameObject.SetActive(true);
                osumousan.transform.localScale = ozekiSize;
                banzukeText.text = "大関級！";
                sound02.PlayOneShot(sound02.clip);
            }
            else if (resultScore >= 15 && resultScore < 25)
            {
                owans_sekiwake.gameObject.SetActive(true);
                osumousan.transform.localScale = sekiwakeSize;
                banzukeText.text = "関脇級！";
                sound03.PlayOneShot(sound03.clip);
            }
            else
            {
                osumousan.transform.localScale = komusubiSize;
                banzukeText.text = "小結級";
                sound04.PlayOneShot(sound04.clip);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene");   
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("TitleScene");
        }
        //MEMO	横綱	大関 関脇 小結
    }
}
