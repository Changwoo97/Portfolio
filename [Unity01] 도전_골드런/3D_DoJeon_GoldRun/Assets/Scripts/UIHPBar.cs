using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : MonoBehaviour
{
    public PlayerHealth playerHealth;

    Slider slider;
    float tempHP;

    void Start()
    {
        if (playerHealth != null)
        {
            tempHP = playerHealth.hp;
        }
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (playerHealth == null)
        {
            enabled = false;
        }

        if (slider != null)
        {
            slider.value = playerHealth.hp / tempHP * 100;
        }
    }
}
