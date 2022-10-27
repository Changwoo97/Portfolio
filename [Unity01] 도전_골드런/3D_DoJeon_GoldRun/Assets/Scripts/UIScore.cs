using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public PlayerScore playerScore;

    float timer;
    int score;

   void Start()
    {
        if (playerScore == null)
        {
            enabled = false;
            return;
        }
        score = 0;
        timer = 0.0f;
    }

    void Update()
    {
        if (playerScore == null)
        {
            enabled = false;
            return;
        }

        timer += Time.deltaTime;

        if (score < playerScore.score && timer >= 0.01f)
        {
            GetComponent<Text>().text = (++score).ToString();
            timer = 0.0f;
        }
    }
}
