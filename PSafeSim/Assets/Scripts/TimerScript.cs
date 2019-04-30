using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    public Text gameOverText;
    public Text statsText;
    public GameObject player;
    public GameObject playerController;
    public AudioClip beep;
    private AudioSource source;
    public float timeLeft = 120.0f;
    private int numShenanigans;
    private float prevTime;

    void Start()
    {
        gameOverText.enabled = false;
        statsText.enabled = false;
        source = GetComponent<AudioSource>();
        prevTime = timeLeft;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Seconds 'til quittin' time: " + Mathf.Round(timeLeft);
            if (Mathf.Round(timeLeft) < Mathf.Round(prevTime) && timeLeft <= 11)
            {
                source.PlayOneShot(beep);
            }
            prevTime = timeLeft;
        }
        else
        {
            timerText.text = "Seconds 'til quittin' time: 0";
            // game over
            numShenanigans = DataScript.Shenanigans;
            gameOverText.enabled = true;
            statsText.enabled = true;
            if (numShenanigans > 0)
            {
                if (numShenanigans == 1)
                {
                    statsText.text = "Congratulations, Deputy.\nYou put an end to 1 shenanigan \nwhile operating sans-Sheriff.";
                } else
                {
                    statsText.text = "Congratulations, Deputy.\nYou put an end to " + numShenanigans.ToString() + " shenanigans \nwhile operating sans-Sheriff.";
                }
            }
            else
            {
                statsText.text = "You stopped no shenanigans.\nWe know you can do better, Deputy.";
            }
            // freeze the player
            playerController.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = 0;
            playerController.GetComponent<ThirdPersonCharacter>().m_AnimSpeedMultiplier = 0;

        }
    }
}
