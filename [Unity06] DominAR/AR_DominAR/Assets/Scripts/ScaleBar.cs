using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleBar : MonoBehaviour
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
                slider.value = Game.instance.scale;
                slider.enabled = true;
            }
            else
            {
                slider.enabled = false;
                slider.value = Game.instance.selectedDomino.scale;
                slider.enabled = true;
            }
        }
    }
}
