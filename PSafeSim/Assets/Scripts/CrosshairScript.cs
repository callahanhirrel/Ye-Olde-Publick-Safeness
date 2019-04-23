
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
