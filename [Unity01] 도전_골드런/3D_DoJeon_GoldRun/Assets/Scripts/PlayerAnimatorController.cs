using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    Animator ani;
    PlayerMove playerMove;
    float preY;
    bool isExcuting;

    void Start()
    {
        ani = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        if (ani == null)
        { 
            enabled = false;
        }
        preY = transform.position.y;
        isExcuting = false;
    }

    void Update()
    {
        if (playerMove != null)
        {
            if (playerMove.isJumping == true)
            {
                if (isExcuting == false)
                {
                    ani.SetTrigger("tJumpUp");
                    isExcuting = true;
                }

                if (preY > transform.position.y)
                {
                    ani.SetTrigger("tJumpDown");
                }
                preY = transform.position.y;
            }
            else
            {
                isExcuting = false;
            }
        }
    }
}
