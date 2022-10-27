using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public GameObject mainBlade;
    public GameObject tailBlade;

    private AudioSource audioSource;

    public bool isTurnedOn = false;

    public float mainBladeSpeed = 0f;
    public float tailBladeSpeed = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isTurnedOn)
        {
            if (mainBladeSpeed < 1800f)
            {
                mainBladeSpeed += 200f * Time.deltaTime;
            }

            if (tailBladeSpeed < 2880f)
            {
                tailBladeSpeed += 320f * Time.deltaTime;
            }
        }
        else
        {
            mainBladeSpeed =
                mainBladeSpeed > 0f ? mainBladeSpeed - 200f * Time.deltaTime : mainBladeSpeed = 0f;
            tailBladeSpeed =
                tailBladeSpeed > 0f ? tailBladeSpeed - 320f * Time.deltaTime : tailBladeSpeed = 0f;
        }

        if (mainBlade != null)
        {
            mainBlade.transform.Rotate(0f, -mainBladeSpeed * Time.deltaTime, 0f);
        }

        if (tailBlade != null)
        {
            tailBlade.transform.Rotate(tailBladeSpeed * Time.deltaTime, 0f, 0f);
        }

        if (audioSource != null)
        {
            if (mainBladeSpeed > 0f && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else if (mainBladeSpeed <= 0f)
            {
                audioSource.Stop();
            }
        }
    }

    public void EngineStartStop()
    {
        if (!enabled)
        {
            return;
        }

        isTurnedOn = !isTurnedOn;
    }
}
