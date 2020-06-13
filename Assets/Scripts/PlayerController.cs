using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public joyConTest _joyConTest;

    private Vector3 setPos;
    //食べた累計
    public static int eatCount = 0;
    //スコア代入用
    public int scoreCount;
    //MAX５ たまったらまんぷく
    public int manpukuCount = 0;

    public Slider slider;
    public Text manpukuText;
    public GameObject atodekeshitaiYatsu;

    private AudioSource sound01;
    private AudioSource sound02;
    private AudioSource sound03;
    private AudioSource sound04;
    private AudioSource sound05;

    public bool MoveLock = false;
    public bool isPlaying = false;
    bool KeyMode = false;
    bool JoyConMode = false;
    bool manpukuSoundPlay = false;

    public enum PlayerState
    {
        Center,
        Right,
        Left,
        Manpuku,
        Drink,
        Eat_Right,
        Eat_Left,
        Hot
    }

    public PlayerState currentPlayerState;

    // Start is called before the first frame update
    void Start()
    {
        setPos = this.transform.position;
        slider.maxValue = 5;
        slider.value = manpukuCount;

        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
        sound03 = audioSources[2];
        sound04 = audioSources[3];
        sound05 = audioSources[4];

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentPlayerState);
        if (isPlaying == false)
        {
            eatCount = 0;
            if (Input.GetKey(KeyCode.K))
            {
                sound04.PlayOneShot(sound04.clip);
                KeyMode = true;
                atodekeshitaiYatsu.gameObject.SetActive(false);
                isPlaying = true;

            }
            if (Input.GetKey(KeyCode.J))
            {
                sound04.PlayOneShot(sound04.clip);
                JoyConMode = true;
                atodekeshitaiYatsu.gameObject.SetActive(false);
                isPlaying = true;
            }

        }

        if (KeyMode == true)
        {
            KeyPlayMode();

        }
        if (JoyConMode == true)
        {
            JoyConPlayMode();

        }

        if (isPlaying == true)
        {
            //まんぷくゲージ
            //スライダー表示
            slider.gameObject.SetActive(true);
            //テキスト表示
            manpukuText.gameObject.SetActive(true);
            manpukuText.text = (manpukuCount + " / 5");
            //Max5
            slider.value = manpukuCount;
            //スコア代入
            scoreCount = eatCount;
            //Debug.Log(eatCount);

            //まんぷく状態
            if (manpukuCount >= 5 && currentPlayerState != PlayerState.Manpuku)
            {
                currentPlayerState = PlayerState.Manpuku;
                //音鳴らす
                if (manpukuSoundPlay == false)
                {
                    sound05.PlayOneShot(sound05.clip);
                    manpukuSoundPlay = true;
                }
                //Manpuku = true;
                Debug.Log("onakaippai....");
                MoveLock = true;
                this.transform.position = setPos;

                //3秒後リリース
                Invoke("Release", 3.0f);
            }

            //ゲーム終了
            if (gameManager.timer < 0.0f)
            {
                Debug.Log("shuryo!");
                MoveLock = true;
                this.transform.position = setPos;
            }
        }

    }

    //keyMODE
    void KeyPlayMode()
    {
        if (MoveLock == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && currentPlayerState == PlayerState.Center)
            {
                if (currentPlayerState != PlayerState.Eat_Left)
                {
                    currentPlayerState = PlayerState.Left;
                }
                this.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.RightArrow) && currentPlayerState == PlayerState.Center)
            {
                if (currentPlayerState != PlayerState.Eat_Right)
                {
                    currentPlayerState = PlayerState.Right;
                }
                this.transform.position = new Vector3(5.3f, 0.0f, 0.0f);
            }
            if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                && currentPlayerState != PlayerState.Drink)
            {
                currentPlayerState = PlayerState.Center;
                this.transform.position = setPos;
            }
            if (Input.GetKeyDown(KeyCode.Space) && manpukuCount != 0 && currentPlayerState == PlayerState.Center)
            {
                DrinkWater();
            }
        }
    }

    //水を飲む
    public void DrinkWater()
    {
        if (currentPlayerState != PlayerState.Drink)
        {
            Invoke("Release2", 0.30f);
        }
        currentPlayerState = PlayerState.Drink;
        sound01.Play();
        sound02.Stop();
        Debug.Log("drink water!");
        manpukuCount--;
    }

    //joyconMODE
    public void JoyConPlayMode()
    {
        if (MoveLock == false)
        {
            GetComponent<joyConTest>().enabled = true;
            GetComponent<JoyconManager>().enabled = true;

        }
    }

    //ロック解除
    void Release()
    {
        Debug.Log("Release");
        MoveLock = false;
        if (currentPlayerState == PlayerState.Manpuku)
        {
            manpukuCount = 0;
        }
        currentPlayerState = PlayerState.Center;
        sound02.Stop();
        sound05.Stop();
        manpukuSoundPlay = false;
    }

    void Release2()
    {
        currentPlayerState = PlayerState.Center;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //そばを食べたら
        if (other.gameObject.tag == "Soba" &&
           (currentPlayerState != PlayerState.Eat_Left || currentPlayerState != PlayerState.Eat_Right))
        {
            if(currentPlayerState == PlayerState.Right)
            {
                currentPlayerState = PlayerState.Eat_Right;
            }
            if (currentPlayerState == PlayerState.Left)
            {
                currentPlayerState = PlayerState.Eat_Left;
            }

            //if (manpukuCount < 4 && currentPlayerState != PlayerState.Hot && currentPlayerState != PlayerState.Drink)
            //{
            //    Debug.Log("eat");
            //    Invoke("Release2", 0.50f);
            //}
            sound03.Play();
            sound02.Stop();
            sound01.Stop();
            Destroy(other.gameObject);
            eatCount++;
            manpukuCount++;
            this.transform.position = setPos;
            this.transform.localScale += new Vector3(0.07f, 0.01f, 0.0f);
        }

        //辛いそばを食べたら
        if (other.gameObject.tag == "SpicySoba" && currentPlayerState != PlayerState.Hot)
        {
            currentPlayerState = PlayerState.Hot;
            MoveLock = true;
            this.transform.position = setPos;
            if (manpukuCount < 4)
            {
                Invoke("Release", 1.3f);
            }
            sound02.Play();
            Debug.Log("OMG!");
            Destroy(other.gameObject);
            manpukuCount++;
        }
    }

    public static int getEatCount()
    {
        return eatCount;
    }

}
