using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button PlayButton;
    public Button HowToPlayButton;
    public Button BackToMenuButton;
    public Text HowToPlayText;

    void Start()
    {
        BackToMenuButton.gameObject.SetActive(false);
        HowToPlayText.gameObject.SetActive(false);
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ShowHowToPlay()
    {
        PlayButton.gameObject.SetActive(false);
        HowToPlayButton.gameObject.SetActive(false);

        HowToPlayText.gameObject.SetActive(true);
        BackToMenuButton.gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        HowToPlayText.gameObject.SetActive(false);
        BackToMenuButton.gameObject.SetActive(false);

        PlayButton.gameObject.SetActive(true);
        HowToPlayButton.gameObject.SetActive(true);
    }
}
