using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameConstants;

public class PlayerMove : MonoBehaviour
{
    public float speed, jumpPower, laneWidth;

    public bool isJumping { get; set; }
    public bool arrowL { get; set; }
    public bool arrowR { get; set; }
    public bool jump { get; set; }

    Rigidbody playerRigidbody;
    Lane lane, preLane;
    float timer;
    bool isChangingLane;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        lane = Lane.middle;
        preLane = lane;
        isJumping = false;
        arrowL = false;
        arrowR = false;
        timer = 0f;
        isChangingLane = false;
    }

    void Update()
    {
        if (isJumping == false)
        {
            timer += Time.deltaTime;

            if (arrowL == true)
            {
                transform.rotation =
                    Quaternion.LookRotation(Vector3.forward + Vector3.left);
                preLane = lane;
                lane = (lane == Lane.middle) ? Lane.left : Lane.middle;
                isChangingLane = true;
                arrowL = false;
            }
            else 
            {
                arrowL = false;
            }

            if (arrowR == true)
            {
                transform.rotation =
                    Quaternion.LookRotation(Vector3.forward + Vector3.right);
                preLane = lane;
                lane = (lane == Lane.middle) ? Lane.right : Lane.middle;
                isChangingLane = true;
                arrowR = false;
            }
            else 
            {
                arrowR = false;
            }

            if (jump == true && timer >= 0.05f)
            {
                playerRigidbody.AddForce(0.0f, jumpPower, 0.0f);
                isJumping = true;
                jump = false;
            }
            else 
            {
                jump = false;
            }

            if (lane == Lane.left && (transform.position.x <= -laneWidth))
            {
                transform.rotation =
                    Quaternion.LookRotation(Vector3.forward);
                isChangingLane = false;
            }
            if (lane == Lane.middle)
            {
                if (preLane == Lane.left && transform.position.x >= 0.0f)
                {
                    transform.rotation =
                        Quaternion.LookRotation(Vector3.forward);
                    isChangingLane = false;
                }
                if (preLane == Lane.right && transform.position.x <= 0.0f)
                {
                    transform.rotation =
                        Quaternion.LookRotation(Vector3.forward);
                    isChangingLane = false;
                }
            }
            if (lane == Lane.right && (transform.position.x >= laneWidth))
            {
                transform.rotation =
                    Quaternion.LookRotation(Vector3.forward);
                isChangingLane = false;
            }
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetArrowL()
    {
        if (arrowR == false && lane != Lane.left &&isChangingLane == false)
        {
            arrowL = true;
        }
    }

    public void SetArrowR()
    {
        if (arrowL == false && lane != Lane.right && isChangingLane == false)
        {
            arrowR = true;
        }
    }

    public void SetJump()
    {
        if (arrowL == false && arrowR == false && isChangingLane == false)
        {
            jump = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        { 
            isJumping = false;
            timer = 0f;
        }
    }
}
