using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Transform playerT;
    public GameObject goldBar, goldCoin;
    public float laneWidth, startPointZ, endPointZ, interval;

    float z;

    void Start()
    {
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
            for (float x = -laneWidth; x <= laneWidth; x += laneWidth)
            {
                float make = Random.Range(0.0f, 1.0f);

                if (make < 0.8f)
                {
                    float num = Random.Range(0.0f, 1.0f);

                    if (num < 0.3f)
                    {
                        Instantiate(goldBar, new Vector3(x, 1.25f, z), transform.rotation);
                    }
                    else
                    {
                        Instantiate(goldCoin, new Vector3(x, 1.25f, z), transform.rotation);
                    }
                }
            }

            z += interval;
        }
    }
}