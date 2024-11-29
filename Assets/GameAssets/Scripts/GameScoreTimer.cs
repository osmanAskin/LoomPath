using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreTimer : MonoBehaviour
{
    public static float ElapsedTime { get; private set; }

    private void Update()
    {
        ElapsedTime += Time.deltaTime;
    }
}
