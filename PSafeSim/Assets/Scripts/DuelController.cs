
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DuelController : MonoBehaviour
{
    public Camera cam;
    private AudioSource audioSource;
    private float timeToEnemySpawn;
    public float timeLimit = 10.0f - (DataScript.Shenanigans * 0.5f);
    public GameObject target;
    private bool targetSpawned;
    public GameObject explosion;

    void Start()
    {
        var random = new System.Random();
        timeToEnemySpawn = random.Next(0, 5);
        audioSource = cam.GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (!targetSpawned)
            {
                if (timeToEnemySpawn > 0) // Enemy has not spawned yet
                {
                    timeToEnemySpawn -= Time.deltaTime;
                }
                else // Enemy spawn timer reaches 0
                {
                    targetSpawned = true;
                    var xPos = Random.Range(-10f, 10f);
                    var yPos = Random.Range(-4f, 4f);
                    var spawnPosition = new Vector2(xPos, yPos);
                    Instantiate(target, spawnPosition, Quaternion.identity);
                }
            }
            else // target has spawned
            {
                if (timeLimit > 0) // time is left in this event
                {
                    timeLimit -= Time.deltaTime;
                }
                else
                {
                    Destroy(target);

                    SceneManager.LoadScene("Game");
                }
            }
        }
    }
}
