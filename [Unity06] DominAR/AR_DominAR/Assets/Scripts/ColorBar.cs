using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBar : MonoBehaviour
{
    private List<Image> list = new List<Image>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Image image = transform.GetChild(i).GetComponent<Image>();
            if (image != null)
                list.Add(image);
        }
    }

    private void Update()
    {
        if (Game.instance != null)
        {
            if (Game.instance.selectedDomino == null)
                Update_Color(Game.instance.selectedColor);
            else
                Update_Color(Game.instance.selectedDomino.color);
        }
    }

    private void Update_Color(Color RGB)
    {
        foreach (Image image in list)
        {
            float R = Mathf.Floor(image.color.r * 100f) / 100f;
            float G = Mathf.Floor(image.color.g * 100f) / 100f;
            float B = Mathf.Floor(image.color.b * 100f) / 100f;
            Color temp = new Color(R, G, B, 1f);

            R = Mathf.Floor(RGB.r * 100f) / 100f;
            G = Mathf.Floor(RGB.g * 100f) / 100f;
            B = Mathf.Floor(RGB.b * 100f) / 100f;
            Color selectedColor = new Color(R, G, B, 1f);

            if (temp != selectedColor)
                temp.a = 0.25f;
            image.color = temp;
        }
    }
}
