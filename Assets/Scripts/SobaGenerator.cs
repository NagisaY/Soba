using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SobaGenerator : MonoBehaviour
{
    public GameObject soba;
    public GameObject spicySoba;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SobaGen", 2, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SobaGen()
    {
        Instantiate(soba, new Vector3(-5.0f, 10.0f, 0.0f), Quaternion.identity);
        Instantiate(spicySoba, new Vector3(5.0f, 10.0f, 0.0f), Quaternion.identity);

    }
}
