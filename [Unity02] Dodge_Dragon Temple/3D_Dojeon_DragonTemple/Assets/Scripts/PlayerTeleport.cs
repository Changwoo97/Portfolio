using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject pTeleportEffect;
    private AudioSource audioSource;
    public AudioClip teleportSound;
    public float teleportDelayTime = 3f;

    public float teleportDelayTimer { get; set; }
    public bool teleportMode { get; set; }
    public bool isTeleporting { get; set; }

    private GameObject startTeleportEffect, endTeleportEffect;
    private RaycastHit hit;
    private bool teleportBtn, cancelBtn;

    public void SetTeleportBtn()
    { 
        teleportBtn = true;
    }

    public void SetCancelBtn()
    { 
        cancelBtn = true;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        teleportDelayTimer = teleportDelayTime;
        teleportMode = false;
        isTeleporting = false;

        startTeleportEffect = null;
        endTeleportEffect = null;
        teleportBtn = false;
        cancelBtn = false;
    }

    private void Update()
    {
        teleportDelayTimer += Time.deltaTime;

        if ((teleportBtn == true || Input.GetKeyDown(KeyCode.LeftControl)) &&
            (teleportMode == false) && (isTeleporting == false) &&
            (teleportDelayTimer >= teleportDelayTime))
        {
            teleportBtn = false;
            teleportMode = true;
        }
        else
        {
            teleportBtn = false;
        }

        if (teleportMode == true && (Input.GetKeyDown(KeyCode.Escape) == true || cancelBtn == true))
        {
            teleportMode = false;
            cancelBtn = false; 
            isTeleporting = false;
        }

        if (teleportMode == true)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                isTeleporting = true;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Floor")))
                {
                    if (GetComponent<PlayerMove>() != null)
                    {
                        GetComponent<PlayerMove>().enabledUpdate = false;

                        if (GetComponent<PlayerMove>().pointObj != null)
                        {
                            Destroy(GetComponent<PlayerMove>().pointObj);
                        }
                    }

                    if (pTeleportEffect != null)
                    {
                        startTeleportEffect =
                            Instantiate(pTeleportEffect, transform.position, Quaternion.identity);
                        endTeleportEffect =
                            Instantiate(pTeleportEffect, hit.point, Quaternion.identity);
                    }
                    teleportMode = false;
                    Invoke("Teleport", 0.3f);
                }
            }
        }
    }

    private void Teleport()
    {
        transform.position = hit.point;

        if (audioSource != null)
        {
            audioSource.PlayOneShot(teleportSound);
        }

        if (GetComponent<PlayerMove>() != null)
        {
            GetComponent<PlayerMove>().movePos = transform.position;
        }

        Invoke("EndTeleport", 0.3f);
    }

    private void EndTeleport()
    {
        if (startTeleportEffect != null)
        {
            Destroy(startTeleportEffect);
            startTeleportEffect = null;
        }
        if (endTeleportEffect != null)
        {
            Destroy(endTeleportEffect);
            endTeleportEffect = null;
        }

        if (GetComponent<PlayerMove>() != null)
        {
            GetComponent<PlayerMove>().enabledUpdate = true;
        }

        isTeleporting = false;
        teleportDelayTimer = 0f;
    }
}
