using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer { get; set; }

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        if (text != null)
        { 
            text.text = "Time: " + ((int)timer).ToString();
        }
    }
}
