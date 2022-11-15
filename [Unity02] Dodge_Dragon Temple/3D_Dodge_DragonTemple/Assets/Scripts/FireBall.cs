using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject pExplosion;

    private PlayerHealth cPlayerHealth;
    private Rigidbody cRigidbody;

    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null)
        { 
            enabled = false;
            return;
        }
        cPlayerHealth = player.GetComponent<PlayerHealth>();
        cRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cRigidbody != null)
        {
            cRigidbody.velocity = Vector3.zero;
        }

        if (pExplosion != null)
        {
            Instantiate(pExplosion, transform.position, Quaternion.identity);
        }

        if (other.tag == "Player")
        {
            if (cPlayerHealth != null)
            {
                cPlayerHealth.Damage(20f);
            }
        }

        Destroy(gameObject, 1f);
    }
}
