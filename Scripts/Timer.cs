using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 10;

    void Update()
    {
        if (GameManager.isStart)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                GameManager.gameManager.IncreaseSpeed();
                timeRemaining = 10;
            }
        }
    }
}
