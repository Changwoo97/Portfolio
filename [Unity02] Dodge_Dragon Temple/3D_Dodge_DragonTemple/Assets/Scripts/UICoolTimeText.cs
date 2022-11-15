using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoolTimeText : MonoBehaviour
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
                    if (GetComponent<Text>() != null)
                    {
                        GetComponent<Text>().enabled = true;
                    }
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
                        if (GetComponent<Text>() != null)
                        {
                            GetComponent<Text>().enabled = false;
                            GetComponent<Text>().text = "";
                        }
                        renewTimer = 0f;
                        return;
                    }

                    if (GetComponent<Text>() != null && cPlayerTeleport != null)
                    {
                        float i = cPlayerTeleport.teleportDelayTime - cPlayerTeleport.teleportDelayTimer;
                        GetComponent<Text>().text = ((int)i + 1).ToString();
                    }
                }
            }
        }
    }
}
