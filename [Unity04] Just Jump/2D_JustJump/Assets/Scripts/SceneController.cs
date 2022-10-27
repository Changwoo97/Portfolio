using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextSceneName;

    public RectTransform canvas;

    private float timer = 0f;
    private float exitTimer = 0f;
    private bool escape = false;


    private void Update()
    {
        if (canvas == null)
        {
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= 0.1f
            && canvas.rect.width * (10f / 100f) < Input.mousePosition.x
            && Input.mousePosition.x < canvas.rect.width * (1f - 10f / 100f)
            && canvas.rect.height * (10f / 100f) < Input.mousePosition.y
            && Input.mousePosition.y < canvas.rect.height * (1f - 10f / 100f))
        {
            SceneManager.LoadScene(nextSceneName);
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (escape == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ShowAndroidToastMessage("뒤로가기 버튼을 한 번 더 누르시면 종료됩니다.");
                    escape = true;
                    exitTimer = 0f;
                }
            }
            else // escape == true
            {
                exitTimer += Time.deltaTime;

                if (exitTimer > 3f)
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
