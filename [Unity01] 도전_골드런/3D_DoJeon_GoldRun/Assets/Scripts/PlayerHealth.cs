using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public SceneController sceneManager;
    public float hp;

    PlayerMove playerMove;
    TwinkleColor twinkleColor;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        twinkleColor = GetComponent<TwinkleColor>();
    }

    public void Damage(float damage)
    {
        if (hp <= 0.0f || damage <= 0.0f)
        {
            return;
        }

        if (twinkleColor != null)
        {
            if (twinkleColor.enabled == true)
            {
                return;
            }
        }

        if (hp - damage < 0.0f)
        {
            hp = 0.0f;
        }
        else 
        {
            hp -= damage;
        }

        if (twinkleColor != null)
        {
            twinkleColor.enabled = true;
        }

        if (hp <= 0.0f)
        {
            if (playerMove != null)
            {
                playerMove.enabled = false;
            }

            if (sceneManager != null)
            {
                sceneManager.missionFail();
            }
        }
    }
}
