using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float damage, attackDelay;
    public bool alwaysOn;
    public float onTime, offTime;

    Transform playerTransform, laserTransform;
    PlayerHealth playerHealth;
    LineRenderer lineRenderer;

    Vector3 pos;
    Ray ray;

    float timer, attackTimer, maxDist;
    int layerMask;
    bool isOn;

    void Start()
    {
        GameObject player = GameObject.Find("Player");

        playerTransform = player.transform;
        laserTransform = GetComponentInParent<Transform>();
        playerHealth = player.GetComponent<PlayerHealth>();
        lineRenderer = GetComponent<LineRenderer>();

        pos = transform.Find("Pos").position;

        Vector3 dir = pos - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);

        ray = new Ray(transform.position, transform.forward);
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, pos);
        }

        timer = 0.0f;
        attackTimer = 0.0f;
        maxDist = Vector3.Distance(transform.position, pos);
        layerMask = LayerMask.GetMask("Raycast");
        isOn = false;
    }

    void Update()
    {
        if (alwaysOn == false && onTime > 0.0f && offTime > 0.0f)
        {
            timer += Time.deltaTime;

            if (isOn == true && timer >= onTime)
            {
                isOn = false;
                timer = 0.0f;
            }
            if (isOn == false && timer >= offTime)
            {
                isOn = true;
                timer = 0.0f;
            }
        }

        if (alwaysOn == true || isOn == true)
        {
            lineRenderer.enabled = true;
            attackTimer += Time.deltaTime;

            if (Physics.Raycast(ray, out RaycastHit hit, maxDist, layerMask) == true)
            {
                if ((playerHealth != null) && (attackTimer >= attackDelay))
                {
                    playerHealth.Damage(damage);
                    attackTimer = 0.0f;
                }
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }
}
