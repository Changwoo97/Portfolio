using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private bool tDie;

    private void Start()
    {
        tDie = false;
    }

    private void Update()
    {
        if (GetComponent<Animator>() != null)
        {
            if (GetComponent<PlayerMove>() != null)
            {
                if (GetComponent<PlayerMove>().isWalking == true)
                {
                    GetComponent<Animator>().SetBool("bWalk", true);
                }
                else
                {
                    GetComponent<Animator>().SetBool("bWalk", false);
                }
            }

            if (GetComponent<PlayerHealth>() != null)
            {
                if (GetComponent<PlayerHealth>().isDied == true && tDie == false)
                {
                    GetComponent<Animator>().SetTrigger("tDie");
                    tDie = true;
                }
            }
        }
        else
        { 
            enabled = false;
        }
    }
}
