using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointerController : MonoBehaviour
{
    public GameObject pointer;
    private GameObject objective;

    // Update is called once per frame
    void Update()
    {
        objective = GameObject.FindGameObjectWithTag("interactable");
        if (objective == null)
        {
            objective = GameObject.FindGameObjectWithTag("enemyCowboy");
        }

        if (objective) {
            pointer.transform.LookAt(objective.transform);
        }
        
    }
}
