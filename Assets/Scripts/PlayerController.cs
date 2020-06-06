using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer MainSpriteRenderer;
    public GameManager gameManager;
    public joyConTest _joyConTest;

    Vector3 setPos;
    public static int eatCount = 0;
    public int manpukuCount = 0;
    public int scoreCount;
    public Slider slider;
    public Text manpukuText;
    public Text atodekeshitaiText;

    public Sprite[] Sprites;

    private AudioSource sound01;
    private AudioSource sound02;
    private AudioSource sound03;
    private AudioSource sound04;
    private AudioSource sound05;

    public bool MoveLock = false;
    public bool isPlaying = false;
    bool Manpuku = false;
    bool KeyMode = false;
    bool JoyConMode = false;
    bool manpukuSoundPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //DontDestroyOnLoad(this);
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
        //Debug.Log(MoveLock);
        if (isPlaying == false)
        {
            if (Input.GetKey(KeyCode.K))
            {
                sound04.PlayOneShot(sound04.clip);
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
            slider.gameObject.SetActive(true);
            manpukuText.gameObject.SetActive(true);
            slider.value = manpukuCount;
            manpukuText.text = (manpukuCount + " / 5");
            scoreCount = eatCount;
            //Debug.Log(eatCount);

            if (manpukuCount >= 5)
            {
                if(manpukuSoundPlay == false)
                {
                    sound05.PlayOneShot(sound05.clip);
                    manpukuSoundPlay = true;
                }
                Manpuku = true;
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
                Invoke("DrinkWater", 0.0f);
                //sound01.Play();
                //sound02.Stop();

                MainSpriteRenderer.sprite = Sprites[2];
                Debug.Log("drink water!");
                manpukuCount--;
                Debug.Log(manpukuCount);

            }
        }
    }

    public void JoyConPlayMode()
    {
        isPlaying = true;
        if (MoveLock == false)
        {
            GetComponent<joyConTest>().enabled = true;
            GetComponent<JoyconManager>().enabled = true;

        }
    }

    public void DrinkWater()
    {
        sound01.Play();
        sound02.Stop();

        MainSpriteRenderer.sprite = Sprites[2];
        Debug.Log("drink water!");
        manpukuCount--;
        Debug.Log(manpukuCount);
    }

    void Release()
    {
        MainSpriteRenderer.sprite = Sprites[0];
        MoveLock = false;
        if(Manpuku == true)
        {
            manpukuCount = 0;
            Manpuku = false;
        }
        sound02.Stop();
        sound05.Stop();
        manpukuSoundPlay = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if(other.gameObject.tag == "Soba")
            {
                MainSpriteRenderer.sprite = Sprites[0];
                sound03.Play();
                sound02.Stop();
                sound01.Stop();
                Debug.Log("eat");
                Destroy(other.gameObject);
                eatCount++;
                manpukuCount++;
            this.transform.localScale += new Vector3(0.07f,0.01f,0.0f);
            }
            if (other.gameObject.tag == "SpicySoba")
            {
                MoveLock = true;
                this.transform.position = setPos;
                Invoke("Release", 1.0f);
                MainSpriteRenderer.sprite = Sprites[1];
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
