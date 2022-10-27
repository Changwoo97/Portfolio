using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score { get; set; }

    void Start()
    {
        score = 0;
    }
}
