
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelController : MonoBehaviour
{
    public Camera cam;
    private AudioSource audioSource;
    private float timeToEnemySpawn;
    public float timeLimit = 10.0f - (DataScript.Shenanigans * 0.5f);
    public GameObject squares;

    void Start()
    {
        
        var random = new System.Random();
        timeToEnemySpawn = random.Next(0, 10);
        audioSource = cam.GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (timeToEnemySpawn > 0) // Enemy has not spawned yet
            {
                timeToEnemySpawn -= Time.deltaTime;
            }
            else // Enemy spawn timer reaches 0
            {
                
            }
        }
    }
}
