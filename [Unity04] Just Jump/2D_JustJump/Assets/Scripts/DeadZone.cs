using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.instance.platforms.Count > 0)
        {
            transform.position =
                GameManager.instance.platforms[0].transform.position
                + Vector3.down * 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.EndGame();
        }
    }
}
