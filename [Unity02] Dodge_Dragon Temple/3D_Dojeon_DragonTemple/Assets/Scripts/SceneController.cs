using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject[] turnOff;
    public GameObject[] turnOn;
    public Timer timer;
    public Text bestTime, yourTime;

    public int nextSceneNumber;

    public void LoadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneNumber);
    }

    public void GameRestart()
    {
        Time.timeScale = 1f;    
        SceneManager.LoadScene("Play");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        for (int i = 0; i < turnOff.Length; i++)
        {
            turnOff[i].SetActive(false);
        }

        for (int i = 0; i < turnOn.Length; i++)
        {
            turnOn[i].SetActive(true);
        }

        if (timer != null)
        {
            if (PlayerPrefs.GetInt("BestTime") < timer.timer)
            {
                PlayerPrefs.SetInt("BestTime", (int)(timer.timer));
            }
        }

        if (bestTime != null)
        {
            bestTime.text = "BestTime : " + PlayerPrefs.GetInt("BestTime");
        }

        if (yourTime != null)
        { 
            yourTime.text = "YourTime : " + (int)(timer.timer);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
