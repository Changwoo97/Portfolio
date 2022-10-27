using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerT;

    void Update()
    {
        if (playerT != null)
        {
            transform.position =
                new Vector3(0.0f, 4.0f, playerT.position.z - 10.0f);
        }
    }
}
