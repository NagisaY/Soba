using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    Vector3 setPos;
    public static int eatCount = 0;
    public int scoreCount;

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

        if (gameManager.timer > 0.0f)
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
        }
        else
        {
            this.transform.position = setPos;
            //this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Soba")
        {
            Debug.Log("eat");
            Destroy(other.gameObject);
            eatCount++;
        }
        if (other.gameObject.tag == "SpicySoba")
        {
            Debug.Log("OMG!");
            Destroy(other.gameObject);
        }
    }

    public static int getEatCount()
    {
        return eatCount;
    }
}
