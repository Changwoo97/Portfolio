using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBorad : MonoBehaviour
{
    void LateUpdate()
    {
        transform.rotation =
            Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
