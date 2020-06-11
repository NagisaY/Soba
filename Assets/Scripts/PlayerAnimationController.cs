using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimationController : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerController playerController;
    private Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.isPlaying == true)
        {
            if (playerController.eatSpicySoba == true)
            {
                animator.SetBool("Karai", true);
                Debug.Log("karaaaaaaaai");
            }
            animator.SetBool("Turn_right", false);
            animator.SetBool("Turn_left", false);

            if (playerController.MoveLock == false)
            {
                //animator.SetBool("Mannpuku", false);
                if (playerController.eatSoba == false || playerController.eatSpicySoba == false)
                {
                    animator.SetBool("Eat_right", false);
                    animator.SetBool("Eat_left", false);

                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    //animator.SetBool("Turn_right", false);
                    animator.SetBool("Turn_left", true);
                    if (playerController.eatSoba == true)
                    {
                        animator.SetBool("Eat_left", true);
                        //if (playerController.Manpuku == true)
                        //{
                        //    animator.SetBool("Mannpuku", true);
                        //}
                    }

                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    //animator.SetBool("Turn_left", false);
                    animator.SetBool("Turn_right", true);
                    if (playerController.eatSoba == true)
                    {
                        animator.SetBool("Eat_right", true);

                    }

                }
                //else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                //{
                //    animator.SetBool("Turn_right", false);
                //    animator.SetBool("Turn_left", false);

                //}
                else if (Input.GetKeyDown(KeyCode.Space) && playerController.manpukuCount != 0)
                {
                    Invoke("DrinkWater", 0.0f);
                }

            }

            if (playerController.eatSpicySoba == false)
            {
                animator.SetBool("Karai", false);
                //animator.SetBool("Turn_right", false);
                //animator.SetBool("Turn_left", false);
                Debug.Log("karaaaaaaaai");
            }



            //else if (playerController.Manpuku == false)
            //{
            //    animator.SetBool("Mannpuku", false);
            //}

            if (gameManager.timer < 0.0f)
            {
                animator.SetBool("Turn_right", false);
                animator.SetBool("Turn_left", false);
            }
            if (playerController.Manpuku == true)
            {
                Debug.Log("mannpuku");
                animator.SetBool("Mannpuku", true);
            }
            else if (playerController.Manpuku == false)
            {
                animator.SetBool("Mannpuku", false);
                //animator.SetBool("Turn_right", false);
                //animator.SetBool("Turn_left", false);
            }
        }


    }

    void KeyPlayMode()
    {

    }

    //public void JoyConPlayMode()
    //{
    //    playerController.isPlaying = true;
    //    if (playerController.MoveLock == false)
    //    {
    //        GetComponent<joyConTest>().enabled = true;
    //        GetComponent<JoyconManager>().enabled = true;

    //    }
    //}

    public void DrinkWater()
    {
        Debug.Log("drink water!");
    }

    void Release()
    {
    }

}
