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
    private Joycon.Button? m_pressedButtonL;
    private Joycon.Button? m_pressedButtonR;
    Vector3 setPos;

    private void Start()
    {
        SetControllers();
        setPos = this.transform.position;
    }

    private void Update()
    {
        var isLeft = m_joyconL.isLeft;
        var name = isLeft ? "Joy-Con (L)" : "Joy-Con (R)";
        var key = isLeft ? "Z キー" : "X キー";
        var button = isLeft ? m_pressedButtonL : m_pressedButtonR;
        var stick = m_joyconL.GetStick();
        var gyro = m_joyconL.GetGyro();
        var accel = m_joyconL.GetAccel();
        var orientation = m_joyconL.GetVector();

        if(accel.y >= 0.5)
        {
            this.transform.position = new Vector3(-5.0f, 0.0f, 0.0f);
        }
        else if (accel.y <= -0.5)
        {
            this.transform.position = new Vector3(5.0f, 0.0f, 0.0f);
        }
        else
        {
            this.transform.position = setPos;

        }


        m_pressedButtonL = null;
        m_pressedButtonR = null;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        SetControllers();

        //foreach (var button in m_buttons)
        //{
        //    if (m_joyconL.GetButton(button))
        //    {
        //        m_pressedButtonL = button;
        //    }
        //    if (m_joyconR.GetButton(button))
        //    {
        //        m_pressedButtonR = button;
        //    }
        //}

        //if(m_joyconL.GetGyro)

        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_joyconL.SetRumble(160, 320, 0.6f, 200);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            m_joyconR.SetRumble(160, 320, 0.6f, 200);
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