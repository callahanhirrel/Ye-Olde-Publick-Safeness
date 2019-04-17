using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ToggleHorse : MonoBehaviour
{
    public GameObject mask;
    bool onHorse = false;
    GameObject thirdPersonController;

    // Start is called before the first frame update
    void Start()
    {
        mask.SetActive(false);
        thirdPersonController = GameObject.Find("ThirdPersonController");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (onHorse == false)
            {
                // activate horse mask
                mask.SetActive(true);
                // increase speed and anim speed multiplier
                thirdPersonController.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = 2;
                thirdPersonController.GetComponent<ThirdPersonCharacter>().m_AnimSpeedMultiplier = 2;
                // play horse sound
                // set onHorse boolean to true
                onHorse = true;
            }
            else
            {
                // deactivate horse mask
                mask.SetActive(false);
                // reset speed and anim speed multipliers to 1
                thirdPersonController.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = 1;
                thirdPersonController.GetComponent<ThirdPersonCharacter>().m_AnimSpeedMultiplier = 1;
                // play dismount sound?
                // set onHorse to false
                onHorse = false;
            }

        }
    }
}
