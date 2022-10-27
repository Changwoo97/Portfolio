using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (Game.instance != null && slider != null)
        {
            if (Game.instance.selectedDomino == null)
            {
                slider.enabled = false;
                slider.value = Game.instance.rotation;
                slider.enabled = true;
            }
            else
            {
                slider.enabled = false;
                slider.value = Game.instance.selectedDomino.rotation;
                slider.enabled = true;
            }
        }
    }
}
