using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject laserV, laserH;
    public float startPointZ, endPointZ, laneWidth, height, interval;

    GameObject player;
    Transform playerT;
    float z;

    void Start()
    {
        player = GameObject.Find("Player");
        playerT = player.transform;
        z = startPointZ;
    }

    void Update()
    {
        if (z > endPointZ)
        {
            enabled = false;
            return;
        }

        if ((z - playerT.position.z) <= interval * 2)
        {
            int instNum = 0;

            for (float j = -laneWidth; j <= laneWidth; j += laneWidth)
            {
                float num = Random.Range(0.0f, 1.0f);

                if (num > 0.5f && instNum < 2)
                {
                    Instantiate(laserV, new Vector3(j, 0.0f, z), Quaternion.identity);
                    instNum++;
                }
            }

            instNum = 0;

            for (float j = 0; j <= height; j += height)
            {
                float num = Random.Range(0.0f, 1.0f);

                if (num > 0.5f && instNum < 1)
                {
                    Instantiate(laserH, new Vector3(0.0f, j, z), Quaternion.identity);
                    instNum++;
                }
            }

            z += interval;
        }
    }
}
