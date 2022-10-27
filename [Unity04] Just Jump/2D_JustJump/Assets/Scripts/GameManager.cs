using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Platform> platformPrefabs;
    public List<Platform> platforms { get; private set; }
    private int jumpCount = 0;

    public int score { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        platforms = new List<Platform>();

        foreach (Platform platform in platformPrefabs)
        { 
            platforms.Add(platform);
        }

        score = 0;
    }

    private void Update()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            float x = platforms[i].transform.position.x;
            float y = 0f;

            if (i < 1)
            {
                platforms[i].SetRigidbodyGravityScale(1f);

                if (Input.GetMouseButtonDown(0) && jumpCount < 2)
                {
                    jumpCount++;
                    platforms[i].SetRigidbodyVelocity(Vector2.zero);
                    platforms[i].SetRigidbodyAddForce(new Vector2(0f, -400f));
                }
                else if (Input.GetMouseButtonUp(0) && platforms[i].GetRigidbodyVelocity().y < 0)
                {
                    Vector2 velocity =
                        new Vector2(platforms[i].GetRigidbodyVelocity().x,
                        platforms[i].GetRigidbodyVelocity().y / 2f);
                    platforms[i].SetRigidbodyVelocity(velocity);
                }

                y = platforms[i].transform.position.y;
            }
            else
            {
                platforms[i].SetRigidbodyGravityScale(0f);
                y = platforms[i - 1].transform.position.y + 3f;
            }

            switch (platforms[i].moveState)
            {
                case Platform.MoveState.None:
                    break;
                case Platform.MoveState.Wait:
                    if (Time.time > platforms[i].timer + platforms[i].waitTime)
                    {
                        if (platforms[i].transform.position.x < -1.5f)
                        {
                            platforms[i].moveState = Platform.MoveState.MoveRight;
                        }
                        else if (-1.5f <= platforms[i].transform.position.x
                            && platforms[i].transform.position.x <= 1.5f)
                        {
                            platforms[i].moveState = Random.Range(0, 2) > 1
                                ? Platform.MoveState.MoveLeft : Platform.MoveState.MoveRight;
                        }
                        else if (1.5f < platforms[i].transform.position.x)
                        {
                            platforms[i].moveState = Platform.MoveState.MoveLeft;
                        }
                    }
                    break;
                case Platform.MoveState.MoveLeft:
                    if (-1.5f < platforms[i].transform.position.x)
                    {
                        x -= platforms[i].moveSpeed * Time.deltaTime;
                    }
                    else
                    {
                        platforms[i].timer = Time.time;
                        platforms[i].moveState = Platform.MoveState.Wait;
                    }
                    break;
                case Platform.MoveState.MoveRight:
                    if (platforms[i].transform.position.x < 1.5f)
                    {
                        x += platforms[i].moveSpeed * Time.deltaTime;
                    }
                    else
                    {
                        platforms[i].timer = Time.time;
                        platforms[i].moveState = Platform.MoveState.Wait;
                    }
                    break;
            }

            platforms[i].transform.position = new Vector3(x, y, 0f);
        }
    }

    public void RenewPlatformList(Platform platform)
    {
        if (!platform.already && !platform.start)
        {
            score++;
        }
        platform.already = true;
        platform.start = false;
        jumpCount = 0;

        if (platforms.Count < 1)
        {
            return;
        }

        int index = -1;

        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i] == platform)
            {
                index = i;
                break;
            }
        }

        if (index < 0)
        {
            return;
        }

        for (int i = 0; i < index; i++)
        { 
            Platform temp = platforms[i];

            platforms.RemoveAt(0);
            platforms.Add(temp);

            temp.enabled = false;
            temp.enabled = true;

            temp.transform.position =
                new Vector3(temp.startXPoint, 0f, 0f);
        }
    }

    public void EndGame()
    {
        PlayerPrefs.SetInt("Score", score);
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        SceneManager.LoadScene("End");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Start");
    }
}
