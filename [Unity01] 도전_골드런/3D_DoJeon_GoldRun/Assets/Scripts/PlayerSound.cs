using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip clipHurt, clipItem, clipJump;

    PlayerHealth playerHealth;
    float preHP;
    PlayerScore playerScore;
    int preScore;
    PlayerMove playerMove;
    bool overlap;
    AudioSource audioSource;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerScore = GetComponent<PlayerScore>();
        playerMove = GetComponent<PlayerMove>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        { 
            enabled = false;
            return;
        }
        if (playerHealth != null)
        {
            preHP = playerHealth.hp;
        }
        if (playerScore != null)
        {
            preScore = playerScore.score;
        }
        if (playerMove != null)
        {
            overlap = false;
        }
    }

    void Update()
    {
        if (playerHealth != null && clipHurt != null)
        {
            if (playerHealth.hp < preHP)
            {
                audioSource.PlayOneShot(clipHurt);
                preHP = playerHealth.hp;
            }
        }

        if (playerScore != null && clipItem != null)
        {
            if (playerScore.score > preScore)
            {
                audioSource.PlayOneShot(clipItem);
                preScore = playerScore.score;
            }
        }

        if (playerMove != null && clipJump != null)
        {
            if (playerMove.isJumping == true && overlap == false)
            {
                audioSource.PlayOneShot(clipJump);
                overlap = true;
            }
            else if(playerMove.isJumping == false && overlap == true)
            {
                overlap = false;
            }
        }
    }
}
