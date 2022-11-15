using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoolTime : MonoBehaviour
{
    private PlayerTeleport cPlayerTeleport;
    private bool turnOnCoolTime;
    private float renewTimer, restCoolTime;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            cPlayerTeleport = player.GetComponent<PlayerTeleport>();

            if (cPlayerTeleport == null)
            {
                enabled = false;
            }
        }
        else
        { 
            enabled = false;
        }
        turnOnCoolTime = false;
        renewTimer = 0f;
        restCoolTime = 0f;
    }

    private void LateUpdate()
    {
        if (cPlayerTeleport != null)
        {
            if (turnOnCoolTime == false)
            {
                if (cPlayerTeleport.isTeleporting == true)
                {
                    turnOnCoolTime = true;
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
            else
            {
                renewTimer += Time.deltaTime;

                if (renewTimer >= 0.3f)
                {
                    restCoolTime = 1f - cPlayerTeleport.teleportDelayTimer / cPlayerTeleport.teleportDelayTime;

                    if (restCoolTime <= 0f)
                    {
                        restCoolTime = 0f;
                        turnOnCoolTime = false;
                        renewTimer = 0f;
                    }

                    transform.localScale = new Vector3(1f, restCoolTime, 1);
                }
            }
        }
    }
}
