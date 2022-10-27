using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    SceneController sceneController;

    void Start()
    {
        sceneController = GetComponentInParent<SceneController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMove>().enabled = false;
            sceneController.missionSuccessT.enabled = true;
            Invoke("sceneController.LoadScene", 3);
        }
    }
}
