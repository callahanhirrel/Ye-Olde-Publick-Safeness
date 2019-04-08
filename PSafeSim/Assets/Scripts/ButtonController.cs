using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    void Start()
    {

    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ShowHowToPlay()
    {
        //Enable popup that shows how to play
        //Modal window?
    }
}
