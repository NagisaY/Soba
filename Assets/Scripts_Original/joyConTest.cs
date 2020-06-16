using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class joyConTest : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;

    public PlayerController playerController;
    Vector3 setPos;

    //bool drinkWaterReady = false;

    private void Start()
    {
        SetControllers();
        setPos = this.transform.position;
    }

    private void Update()
    {

        var accelL = m_joyconL.GetAccel();

        //if (drinkWaterReady == false && accelL.x < 0.0f)
        //{
        //    drinkWaterReady = true;
        //}

        if (playerController.MoveLock == false)
        {
            if (accelL.y >= 0.5)
            {
                if (playerController.currentPlayerState != PlayerController.PlayerState.Eat_Left)
                {
                    playerController.currentPlayerState = PlayerController.PlayerState.Left;
                }
                this.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
            }
            else if (accelL.y <= -0.5)
            {
                if (playerController.currentPlayerState != PlayerController.PlayerState.Eat_Right)
                {
                    playerController.currentPlayerState = PlayerController.PlayerState.Right;
                }
                this.transform.position = new Vector3(5.0f, 0.0f, 0.0f);
            }
            else if (m_joyconL.GetButtonDown(Joycon.Button.DPAD_UP) && playerController.manpukuCount != 0 && this.transform.position == setPos)
            {
                playerController.DrinkWater();
                playerController.currentPlayerState = PlayerController.PlayerState.Drink;
            }
            else if(accelL.y > 0.5 && accelL.y > -0.5 && playerController.currentPlayerState != PlayerController.PlayerState.Drink)
            {
                playerController.currentPlayerState = PlayerController.PlayerState.Center;
                this.transform.position = setPos;
            }
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