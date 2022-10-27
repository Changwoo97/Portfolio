using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinkleColor : MonoBehaviour
{
    public float twinkleTime, endTime;

    SkinnedMeshRenderer meshRenderer;
    float totalTimer, subTimer;
    bool isOn;

    void Start()
    {
        meshRenderer = transform.Find("C_man_1_FBX2013").GetComponent<SkinnedMeshRenderer>();
        totalTimer = 0.0f;
        subTimer = 0.0f;
        isOn = true;
    }

    void Update()
    {
        if ((meshRenderer == null) || (totalTimer >= endTime) || (twinkleTime >= endTime))
        {
            meshRenderer.enabled = true;
            totalTimer = 0.0f;
            enabled = false;
            return;
        }

        totalTimer += Time.deltaTime;
        subTimer += Time.deltaTime;

        if (subTimer >= twinkleTime)
        {
            if (isOn == true)
            {
                meshRenderer.enabled = false;
                isOn = false;
            }
            else 
            {
                meshRenderer.enabled = true;
                isOn = true;
            }
            
            subTimer = 0.0f;
        }
    }
}

