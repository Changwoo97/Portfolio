using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    private PlayerHealth cPlayerHealth;
    private float totalHP;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            enabled = false;
            return;
        }

        cPlayerHealth = player.GetComponent<PlayerHealth>();
        if (cPlayerHealth == null)
        {
            enabled = false;
            return;
        }

        totalHP = cPlayerHealth.hp;
    }

    void Update()
    {
        if (cPlayerHealth != null)
        {
            if (GetComponent<Slider>() != null)
            {
                float value = cPlayerHealth.hp / totalHP;

                if (value < 0f)
                {
                    value = 0f;
                }

                GetComponent<Slider>().value = value;
            }
        }
    }
}
