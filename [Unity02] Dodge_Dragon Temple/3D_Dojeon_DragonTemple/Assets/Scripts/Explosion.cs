using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip audioClipExplosion;
    private float timer;

    void Start()
    {
        timer = 0f;

        AudioSource cAudioSource = GetComponent<AudioSource>();
        if (cAudioSource != null)
        {
            cAudioSource.PlayOneShot(audioClipExplosion);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2f)
        { 
            Destroy(gameObject);
        }
    }
}
