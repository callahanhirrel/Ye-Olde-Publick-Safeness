using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetScript : MonoBehaviour
{
    public GameObject explosion;

    void OnMouseDown()
    {
        DataScript.Shenanigans++;

        var position = transform.position;
        Destroy(transform.gameObject);
        var expl = Instantiate(explosion, position, Quaternion.identity);
        Destroy(expl, 2);

        SceneManager.LoadScene("Game");
    }
}
