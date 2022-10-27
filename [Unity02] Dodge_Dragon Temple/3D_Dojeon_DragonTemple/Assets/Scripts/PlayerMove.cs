using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject pPoint;
    public float moveSpeed = 2f;

    public bool enabledUpdate { get; set; }
    public bool isWalking { get; set; }
    public GameObject pointObj { get; set; }
    public Vector3 movePos { get; set; }

    private float minDist;

    void Start()
    {
        enabledUpdate = true;
        isWalking = false;
        pointObj = null;

        movePos = Vector3.zero;
        minDist = 0.5f;
    }

    void Update()
    {
        if (enabledUpdate == true)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Floor")) == true)
                {
                    if (pointObj != null)
                    {
                        Destroy(pointObj);
                        pointObj = null;
                    }

                    movePos = hit.point;

                    if (pPoint != null)
                    {
                        pointObj = Instantiate(pPoint, movePos + Vector3.up, Quaternion.Euler(-90f, 0f, 0f));
                    }
                }
            }

            float dist = Vector3.Distance(movePos, transform.position);

            if (dist > minDist)
            {
                isWalking = true;

                Vector3 dir = (movePos - transform.position).normalized;
                transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.LookRotation(dir);
            }
            else
            {
                isWalking = false;

                if (pointObj != null)
                {
                    Destroy(pointObj);
                    pointObj = null;
                }
            }
        }
        else 
        { 
            isWalking = false;
        }
    }
}
