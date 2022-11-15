using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITeleportMode : MonoBehaviour
{
    public GameObject cancelBtn;

    GameObject oPlayer;
    PlayerTeleport cPlayerTeleport;

    void Start()
    {
        oPlayer = GameObject.Find("Player");

        if (oPlayer != null)
        {
            cPlayerTeleport = oPlayer.GetComponent<PlayerTeleport>();
        }
    }

    void Update()
    {
        if (cPlayerTeleport != null)
        {
            if (cPlayerTeleport.teleportMode == true)
            {
                if (GetComponent<RawImage>() != null)
                {
                    GetComponent<RawImage>().enabled = true;
                }

                if (cancelBtn != null)
                { 
                    cancelBtn.SetActive(true);
                }
            }
            else
            {
                if (GetComponent<RawImage>() != null)
                {
                    GetComponent<RawImage>().enabled = false;
                }

                if (cancelBtn != null)
                {
                    cancelBtn.SetActive(false);
                }
            }
        }
    }
}
