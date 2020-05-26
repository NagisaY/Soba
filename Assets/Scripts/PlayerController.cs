using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    Vector3 setPos;
    public static int eatCount = 0;
    public static int manpukuCount = 0;
    public int scoreCount;

    bool MoveLock = false;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
        setPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount = eatCount;
        //Debug.Log(eatCount);
        if(MoveLock == false)
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
            if (Input.GetKeyDown(KeyCode.Space) && manpukuCount != 0)
            {
                Debug.Log("drink water!");
                manpukuCount--;
                Debug.Log(manpukuCount);

            }
        }

        if (manpukuCount >= 5)
        {
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

    void Release()
    {
        MoveLock = false;
        manpukuCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Soba")
        {
            Debug.Log("eat");
            Destroy(other.gameObject);
            eatCount++;
            manpukuCount++;
        }
        if (other.gameObject.tag == "SpicySoba")
        {
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
