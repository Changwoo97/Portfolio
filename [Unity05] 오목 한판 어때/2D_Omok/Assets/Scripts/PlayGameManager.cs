using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PlayGameManager : MonoBehaviour {
    [SerializeField] GameObject outPage;

    public void outButton() {
        if (outPage != null) {
            outPage.SetActive(true);
        }
    }

    public void YesButton() => SceneManager.LoadScene("Start");

    public void NoButton() {
        if (outPage != null) {
            outPage.SetActive(false);
        }
    }
}
