using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public static bool isStart = false;
    
    public static int score;

    public float _speed { get; private set; }

    private void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        _speed = 5f;
    }

    public void IsStartTrue()
    {
        UI.ui.Countdown();
    }

    public void IsStartFalse()
    {
        isStart = false;
        UI.ui.TargetLost();
    }

    public void IncreaseSpeed()
    {
        _speed += _speed*20/100;
    }
}
