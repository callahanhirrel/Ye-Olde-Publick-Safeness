using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text text;
    private float timeLeft = 120.0f;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Left:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            //game over
        }
    }
}
