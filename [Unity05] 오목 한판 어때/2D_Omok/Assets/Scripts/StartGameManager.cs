using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class StartGameManager : MonoBehaviour {
    float timer = 0f;
    bool escape = false;

    void Update() {
        if (Application.platform == RuntimePlatform.Android) {
            if (escape == false) {
                if (Input.GetKeyDown(KeyCode.Escape)) {
                    ShowAndroidToastMessage("뒤로가기 버튼을 한 번 더 누르시면 종료됩니다.");
                    escape = true;
                    timer = 0f;
                }
            } else {
                timer += Time.deltaTime;

                if (timer > 3f) {
                    escape = false;
                    return;
                }

                if (Input.GetKeyDown(KeyCode.Escape)) {
                    Application.Quit();
                }
            }
        }

        if (Input.GetMouseButtonDown(0)
            && Screen.width * (5f / 100f) < Input.mousePosition.x
            && Input.mousePosition.x < Screen.width * (1 - 5f / 100f)
            && Screen.height < Input.mousePosition.y
            && Input.mousePosition.y < Screen.height * (1 - 5f / 100f)) {
            SceneManager.LoadScene("Play");
        }
    }

    public void StartButton() => SceneManager.LoadScene("Play");

    void ShowAndroidToastMessage(string message) {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null) {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }
}
