using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public Text bestScore;
    public Text score;

    void Start()
    {
        if (bestScore != null)
        {
            bestScore.text =
                "Best Score: " + PlayerPrefs.GetInt("BestScore");
        }

        if (score != null)
        {
            score.text =
                "Score: " + PlayerPrefs.GetInt("Score");
        }
    }
}
