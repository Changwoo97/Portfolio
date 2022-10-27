using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timer = 0f;
    private bool escape = false;

    public void LoadScene()
    {
        SceneManager.LoadScene("Play");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (escape == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ShowAndroidToastMessage("뒤로가기 버튼을 한 번 더 누르시면 종료됩니다.");
                    escape = true;
                    timer = 0f;
                }
            }
            else // escape == true
            {
                timer += Time.deltaTime;

                if (timer > 3f)
                {
                    escape = false;
                    return;
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
        }
    }

    private void ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
