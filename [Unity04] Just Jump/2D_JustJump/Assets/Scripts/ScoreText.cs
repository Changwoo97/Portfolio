using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (text != null)
        {
            text.text = "Score: " + GameManager.instance.score;
        }
    }
}
