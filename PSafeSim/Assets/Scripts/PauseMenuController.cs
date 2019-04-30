using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PauseMenuController : MonoBehaviour
{
    public Text timerText;
    public GameObject playerController;
    public GameObject pauseMenuPanel;
    private TimerScript timerScript;
    public bool isPaused;
    private float moveSpeedMultiplier;
    private float animSpeedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        timerScript = timerText.GetComponent<TimerScript>();
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                UnPause();
            } 
            else 
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenuPanel.SetActive(true);
        timerText.enabled = false;
        timerScript.isPaused = true;
        isPaused = true;
        moveSpeedMultiplier = playerController.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier;
        animSpeedMultiplier = playerController.GetComponent<ThirdPersonCharacter>().m_AnimSpeedMultiplier;
        playerController.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = 0;
        playerController.GetComponent<ThirdPersonCharacter>().m_AnimSpeedMultiplier = 0;
    }

    private void UnPause()
    {
        pauseMenuPanel.SetActive(false);
        timerText.enabled = true;
        timerScript.isPaused = false;
        isPaused = false;
        playerController.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = moveSpeedMultiplier;
        playerController.GetComponent<ThirdPersonCharacter>().m_AnimSpeedMultiplier = animSpeedMultiplier;
    }
}
