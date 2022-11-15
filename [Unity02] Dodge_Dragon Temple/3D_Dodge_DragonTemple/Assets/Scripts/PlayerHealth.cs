using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public SceneController sc;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public float hp = 100f;
    public float twinkleRateTime = 0.1f, twinkleTime = 1f;

    public bool isDied { get; set; }

    private float postHp;
    private float twinkleRateTimer, twinkleTimer;
    private bool turnOnTwinkle;

    public void Damage(float damage)
    {
        if (hp <= 0f)
        {
            return;
        }

        hp -= damage;

        if (hp <= 0f)
        {
            hp = 0f;
            isDied = true;
            PlayerMove pm = GetComponent<PlayerMove>();
            if (pm != null)
            { 
                pm.enabled = false;
            }
            if (sc != null)
            {
                sc.GameOver();
            }
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        postHp = hp;
        twinkleRateTimer = 0f;
        twinkleTimer = 0f;
        isDied = false;
        turnOnTwinkle = false;
    }

    private void LateUpdate()
    {
        if (hp < postHp && isDied == false)
        {
            twinkleRateTimer = 0f;
            twinkleTimer = 0f;
            turnOnTwinkle = true;

            postHp = hp;
        }

        if (turnOnTwinkle == true && skinnedMeshRenderer != null)
        {
            twinkleRateTimer += Time.deltaTime;
            twinkleTimer += Time.deltaTime;

            if (twinkleRateTimer >= twinkleRateTime)
            {
                if (skinnedMeshRenderer.enabled == true)
                {
                    skinnedMeshRenderer.enabled = false;
                }
                else
                {
                    skinnedMeshRenderer.enabled = true;
                }

                twinkleRateTimer = 0f;
            }

            if (twinkleTimer >= twinkleTime)
            {
                skinnedMeshRenderer.enabled = true;
            }
        }
    }
}
