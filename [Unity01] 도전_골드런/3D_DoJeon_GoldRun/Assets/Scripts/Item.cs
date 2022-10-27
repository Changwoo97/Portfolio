using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score;
    Transform playerTransform;
    bool noOverlap;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        noOverlap = false;
    }

    void Update()
    {
        float turnOffDist = playerTransform.position.z - transform.position.z;

        if (turnOffDist >= 2.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && noOverlap == false)
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                other.GetComponent<PlayerScore>().score += score;
                noOverlap = true;
            }
            Destroy(gameObject);
        }
    }
}
