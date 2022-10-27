using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject play, pause_Btn, pause_Back;

    public bool isPause { get; set; }

    private PlayerMove cPlayerMove;
    private bool pauseBtn;

    public void SetPause()
    { 
        pauseBtn = true;
    }

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        { 
            cPlayerMove = player.GetComponent<PlayerMove>();
        }
        isPause = false;
        pauseBtn = false;
    }

    private void Update()
    {
        if (pauseBtn == true)
        {
            if (isPause == true)
            {
                Time.timeScale = 1f;
                isPause = false;
                if (play != null)
                {
                    play.SetActive(true);
                }
                if (pause_Btn != null)
                {
                    pause_Btn.SetActive(false);
                }
                if (pause_Back != null)
                {
                    pause_Back.SetActive(false);
                }
                if (cPlayerMove != null)
                {
                    cPlayerMove.enabledUpdate = true;
                }
            }
            else
            {
                Time.timeScale = 0f;
                isPause = true;
                if (play != null)
                { 
                    play.SetActive(false);
                }
                if (pause_Btn != null)
                {
                    pause_Btn.SetActive(true);
                }
                if (pause_Back != null)
                { 
                    pause_Back.SetActive(true);
                }
                if (cPlayerMove != null)
                {
                    cPlayerMove.enabledUpdate = false;
                }
            }

            pauseBtn = false;
        }
    }
}
