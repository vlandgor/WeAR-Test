using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI ui { get; private set; }

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private Text score;
    [SerializeField] private Text timer;

    private int countdown;

    private void Awake()
    {
        ui = this;
    }

    private void Start()
    {
        Info();
        countdown = 3;
    }

    public void Info()
    {
        score.text = GameManager.score.ToString();
    }

    public void Countdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        while(countdown > 0)
        {
            timer.text = countdown.ToString();

            yield return new WaitForSeconds(1f);

            countdown--;
        }

        timer.text = "Start";

        yield return new WaitForSeconds(1f);

        GameManager.isStart = true;

        TargetFound();

        countdown = 3;
        timer.text = "";
    }

    public void TargetFound()
    {
        gamePanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void TargetLost()
    {
        gamePanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
