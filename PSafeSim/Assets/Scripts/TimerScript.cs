using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    public Text gameOverText;
    public Text statsText;
    public GameObject player;
    private float timeLeft = 120.0f;
    private int numShenanigans;

    void Start()
    {
        gameOverText.enabled = false;
        statsText.enabled = false;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Seconds 'til quittin' time:" + Mathf.Round(timeLeft);
        }
        else
        {
            timerText.text = "Seconds 'til quittin' time: 0";
            // game over
            numShenanigans = player.GetComponent<PlayerInteract>().numProblemsSolved;
            gameOverText.enabled = true;
            statsText.enabled = true;
            if (numShenanigans > 0)
            {
                statsText.text = "Congratulations, Deputy.\nYou put an end to " + numShenanigans.ToString() + " shenanigans \nwhile operating sans-Sheriff.";
            }
            else
            {
                statsText.text = "You stopped no shenanigans.\nWe know you can do better, Deputy.";
            }

        }
    }
}
