using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    public GameObject player;
    public Text timer;
    public GameObject canvas;
    private TimerScript timerScript;

    void Start()
    {
        timerScript = timer.GetComponent<TimerScript>();
        player.transform.position = DataScript.Location; // Places player wherever they last were
        timerScript.timeLeft = DataScript.TimeLeft; // Sets timer to whatever time is left
        canvas.GetComponent<PauseMenuController>().isPaused = DataScript.IsPaused;
    }
}
