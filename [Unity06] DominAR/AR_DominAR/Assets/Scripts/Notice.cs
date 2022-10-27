using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notice : MonoBehaviour
{
    private Text text;

    private bool isNotifying = false;
    private float appearTime = 0f;
    public float noticeTime = 3f;
    public float disappearTime = 1f;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        if (text == null)
        {
            return;
        }

        if (isNotifying && Time.time >= appearTime + noticeTime)
        {
            text.color = Color.Lerp(text.color, Color.clear, Time.deltaTime);

            if (text.color.a <= 0)
            {
                isNotifying = false;
            }
        }
    }

    public void Notify(string text)
    {
        if (this.text == null)
        {
            return;
        }

        this.text.text = text;
        this.text.color = Color.white;

        isNotifying = true;
        appearTime = Time.time;
    }
}
