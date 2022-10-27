using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    public Notice notice;

    private float timer = 0f;
    private bool second = false;

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (second == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (notice != null)
                        notice.Notify("뒤로가기 버튼을 한 번 더 누르시면 종료됩니다.");

                    second = true;
                    timer = 0f;
                }
            }
            else 
            {
                timer += Time.deltaTime;

                if (timer > 3f)
                {
                    second = false;
                    return;
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Play");
    }
}

