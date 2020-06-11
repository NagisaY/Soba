using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public joyConTest _joyConTest;

    private Vector3 setPos;
    public static int eatCount = 0;
    public int manpukuCount = 0;
    public int scoreCount;
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
    public bool eatSoba = false;
    public bool eatSpicySoba = false;
    public bool Manpuku = false;
    bool KeyMode = false;
    bool JoyConMode = false;
    bool manpukuSoundPlay = false;

    // Start is called before the first frame update
    void Start()
    {
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
        if (isPlaying == false)
        {
            if (Input.GetKey(KeyCode.K))
            {
                sound04.PlayOneShot(sound04.clip);
                KeyMode = true;
                atodekeshitaiYatsu.gameObject.SetActive(false);

            }
            if (Input.GetKey(KeyCode.J))
            {
                sound04.PlayOneShot(sound04.clip);
                JoyConMode = true;
                atodekeshitaiYatsu.gameObject.SetActive(false);

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
                this.transform.position = new Vector3(5.3f, 0.0f, 0.0f);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                this.transform.position = setPos;
            }
            if (Input.GetKeyDown(KeyCode.Space) && manpukuCount != 0 && this.transform.position == setPos)
            {
                eatSoba = false;
                Invoke("DrinkWater", 0.0f);
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

        //Debug.Log("drink water!");
        manpukuCount--;
        //Debug.Log(manpukuCount);
    }

    void Release()
    {
        //Debug.Log("Release");
        MoveLock = false;
        //eatSoba = false;
        eatSpicySoba = false;
        if(Manpuku == true)
        {
            manpukuCount = 0;
            Manpuku = false;
        }
        sound02.Stop();
        sound05.Stop();
        manpukuSoundPlay = false;

    }

    void Release2()
    {
        eatSoba = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if(other.gameObject.tag == "Soba")
            {
                eatSoba = true;
                //MoveLock = true;

                if (manpukuCount < 4 && eatSpicySoba == false)
                {
                    Debug.Log("eat");
                    Invoke("Release2", 0.50f);
                }
                sound03.Play();
                sound02.Stop();
                sound01.Stop();
                Destroy(other.gameObject);
                eatCount++;
                manpukuCount++;
                this.transform.localScale += new Vector3(0.07f,0.01f,0.0f);
            }
            if (other.gameObject.tag == "SpicySoba")
            {
                eatSpicySoba = true;
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
