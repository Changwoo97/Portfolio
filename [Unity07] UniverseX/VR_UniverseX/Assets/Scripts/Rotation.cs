using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Rotation : MonoBehaviour
{
    [SerializeField, Range(0f, 0.1f)] float rps = 0f;

    void Update() 
        => transform.Rotate(Vector3.up * rps * 360f * Time.deltaTime);
    
}
