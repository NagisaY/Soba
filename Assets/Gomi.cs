using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gomi : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;

    Vector3 setPos;
    bool drinkWaterReady = false;


    private void Start()
    {
        SetControllers();
        setPos = this.transform.position;
    }

    private void Update()
    {

        var stickL = m_joyconL.GetStick();
        var gyroL = m_joyconL.GetGyro();
        var accelL = m_joyconL.GetAccel();
        var orientation = m_joyconL.GetVector();

        if(drinkWaterReady == false && accelL.x < 0.0f)
        {
            drinkWaterReady = true;
            Debug.Log(drinkWaterReady);
        }

        if (accelL.y >= 0.5)
            {
                this.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
            }
            else if (accelL.y <= -0.5)
            {
                this.transform.position = new Vector3(5.0f, 0.0f, 0.0f);
            }
        else if (drinkWaterReady == true && accelL.x >= 0.1)
        {
            Debug.Log("aaa");
            this.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
            drinkWaterReady = false;
        }
        else
            {
                this.transform.position = setPos;

            }
        

        if (m_joycons == null || m_joycons.Count <= 0) return;

        SetControllers();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "SpicySoba")
        {
            m_joyconL.SetRumble(160, 320, 0.6f, 200);

        }
    }

    private void SetControllers()
    {
        m_joycons = JoyconManager.Instance.j;
        if (m_joycons == null || m_joycons.Count <= 0) return;
        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);
    }
}