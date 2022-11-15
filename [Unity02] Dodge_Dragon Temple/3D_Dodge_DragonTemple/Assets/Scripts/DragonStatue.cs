using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStatue : MonoBehaviour
{
    public GameObject[] prefab;
    public float minRate = 3f, maxRate = 10f, speed = 8f;

    private Transform playerT;
    private Transform pos;
    CapsuleCollider cc;
    private float timer, timeRate, pHeight;

    private void Start()
    {
        GameObject obj = GameObject.Find("Player");
        if(obj == null)
        {
            enabled = false;
            return;
        }
        playerT = obj.transform;
        pos = transform.Find("Pos");
        cc = obj.GetComponent<CapsuleCollider>();
        if (cc != null)
        {
            pHeight = cc.height / 2f;
        }
        timer = 0f;
        timeRate = Random.Range(minRate, maxRate);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeRate)
        {
            if (prefab.Length > 0 && playerT != null)
            {
                int i = Random.Range(0, prefab.Length);
                Vector3 dir =
                    playerT.position - pos.position + new Vector3(0f, pHeight, 0f);
                GameObject fireBall = 
                    Instantiate(prefab[i], pos.position, Quaternion.LookRotation(dir));
                Rigidbody rb = fireBall.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = dir.normalized * speed;
                }
            }
            timer = 0f;
            timeRate = Random.Range(minRate, maxRate);
        }
    }
}
