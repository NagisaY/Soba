using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    public GameManager gameManager;
    public joyConTest _joyConTest;

    Vector3 setPos;
    public static int eatCount = 0;
    public static int manpukuCount = 0;
    public int scoreCount;
    public Slider slider;
    public Text manpukuText;
    public Text atodekeshitaiText;

    public Sprite[] Sprites;

    public bool MoveLock = false;
    public bool isPlaying = false;
    bool KeyMode = false;
    bool JoyConMode = false;

    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //DontDestroyOnLoad(this);
        setPos = this.transform.position;
        slider.maxValue = 5;
        slider.value = manpukuCount;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(MoveLock);
        if (isPlaying == false)
        {
            if (Input.GetKey(KeyCode.K))
            {
                KeyMode = true;
                atodekeshitaiText.gameObject.SetActive(false);

            }
            if (Input.GetKey(KeyCode.J))
            {
                JoyConMode = true;
                atodekeshitaiText.gameObject.SetActive(false);

            }

        }

        if (KeyMode == true)
        {
            Invoke("KeyPlayMode", 0.0f);

        }
        if (JoyConMode == true)
        {
            Invoke("JoyConPlayMode", 0.0f);

        }

        if (isPlaying == true)
        {
            slider.value = manpukuCount;
            manpukuText.text = ("まんぷくゲージ " + manpukuCount + " / 5");
            scoreCount = eatCount;
            //Debug.Log(eatCount);

            if (manpukuCount >= 5)
            {
                MainSpriteRenderer.sprite = Sprites[3];
                Debug.Log("onakaippai....");
                MoveLock = true;
                this.transform.position = setPos;
                Invoke("Release", 3.0f);
            }
            else if (gameManager.timer < 0.0f)
            {
                Debug.Log("shuryo!");
                MoveLock = true;
                this.transform.position = setPos;
            }
        }

    }

    void KeyPlayMode()
    {
        Debug.Log("keyMODE");
        isPlaying = true;
        if (MoveLock == false)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position = new Vector3(5.0f, 0.0f, 0.0f);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                this.transform.position = setPos;
            }
            if (Input.GetKeyDown(KeyCode.Space) && manpukuCount != 0 && this.transform.position == setPos)
            {
                MainSpriteRenderer.sprite = Sprites[2];
                Debug.Log("drink water!");
                manpukuCount--;
                Debug.Log(manpukuCount);

            }
        }
    }

    void JoyConPlayMode()
    {
        Debug.Log("joyconMODE");
        isPlaying = true;
        if (MoveLock == false)
        {
            GetComponent<joyConTest>().enabled = true;
            GetComponent<JoyconManager>().enabled = true;

            if (Input.GetKeyDown(KeyCode.Space) && manpukuCount != 0 && this.transform.position == setPos)
            {
                MainSpriteRenderer.sprite = Sprites[2];
                Debug.Log("drink water!");
                manpukuCount--;
                Debug.Log(manpukuCount);

            }
        }
    }

    void Release()
    {
        MainSpriteRenderer.sprite = Sprites[0];
        MoveLock = false;
        manpukuCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if(other.gameObject.tag == "Soba")
            {
            MainSpriteRenderer.sprite = Sprites[0];

            Debug.Log("eat");
                Destroy(other.gameObject);
                eatCount++;
                manpukuCount++;
            this.transform.localScale += new Vector3(0.07f,0.01f,0.0f);
            }
            if (other.gameObject.tag == "SpicySoba")
            {
            MainSpriteRenderer.sprite = Sprites[1];

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
