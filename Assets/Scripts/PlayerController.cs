using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 setPos;
    public int eatCount;

    // Start is called before the first frame update
    void Start()
    {
        setPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
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
}
