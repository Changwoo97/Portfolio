using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public PlayerMove playerMove;
    public Text missionSuccessT;
    public Text missionFailT;
    public int nextSceneNumber;

    public void LoadScene()
    {
        SceneManager.LoadScene(nextSceneNumber);
    }

    public void missionFail()
    {
        missionFailT.enabled = true;
        Invoke("LoadScene", 3);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMove>().enabled = false;
            missionSuccessT.enabled = true;
            Invoke("LoadScene", 3);
        }
    }
}
