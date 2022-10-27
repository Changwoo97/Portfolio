using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRemover : MonoBehaviour
{
    Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        float turnOffDist = playerTransform.position.z - transform.position.z;

        if (turnOffDist >= 2.0f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
