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
            //animator.SetBool("Turn_right", false);
            //animator.SetBool("Turn_left", false);

            if (playerController.MoveLock == false)
            {

                if (playerController.currentPlayerState == PlayerController.PlayerState.Drink)
                {
                    animator.SetBool("Drink", true);
                }
                else animator.SetBool("Drink", false);

                if (playerController.currentPlayerState == PlayerController.PlayerState.Center)
                {
                    animator.SetBool("Turn_right", false);
                    animator.SetBool("Turn_left", false);
                }
                else if (playerController.currentPlayerState == PlayerController.PlayerState.Right)
                {
                    animator.SetBool("Turn_right", true);
                    //animator.SetBool("Drink", false);
                }
                else if (playerController.currentPlayerState == PlayerController.PlayerState.Eat_Right)
                {
                    animator.SetBool("Eat_right", true);
                    Debug.Log("hellooooo");
                }
                else
                {
                    animator.SetBool("Turn_right", false);
                    animator.SetBool("Eat_right", false);
                }

                if (playerController.currentPlayerState == PlayerController.PlayerState.Left)
                {
                    animator.SetBool("Turn_left", true);
                    //animator.SetBool("Drink", false);
                }
                else if (playerController.currentPlayerState == PlayerController.PlayerState.Eat_Left)
                {
                    animator.SetBool("Eat_left", true);
                }
                else
                {
                    animator.SetBool("Turn_left", false);
                    animator.SetBool("Eat_left", false);

                }

            }

            if (playerController.currentPlayerState == PlayerController.PlayerState.Hot)
            {
                animator.SetBool("Karai", true);
                Debug.Log("karaaaaaaaai");
            }
            else if (playerController.currentPlayerState != PlayerController.PlayerState.Hot)
            {
                animator.SetBool("Karai", false);
            }

            if (playerController.currentPlayerState == PlayerController.PlayerState.Manpuku)
            {
                Debug.Log("mannpuku");
                animator.SetBool("Mannpuku", true);
            }
            else if (playerController.currentPlayerState != PlayerController.PlayerState.Manpuku)
            {
                animator.SetBool("Mannpuku", false);

            }
            if (gameManager.timer < 0.0f)
            {
                animator.SetBool("Turn_right", false);
                animator.SetBool("Turn_left", false);
                animator.SetBool("Drink", false);

            }
        }

    }

}
