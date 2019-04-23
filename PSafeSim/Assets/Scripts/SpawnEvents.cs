using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvents : MonoBehaviour
{
    private float spawnZoneCenterX;
    private float spawnZoneCenterZ;
    public float spawnZoneRadius;
    public float y;
    public float objectRadius;
    public GameObject wagon;
    public GameObject enemyCowboy;
    public bool testFlag = true;
    public int numTests = 5;
    private float spawnMinX;
    private float spawnMaxX;
    private float spawnMinZ;
    private float spawnMaxZ;
    private GameObject newObject;

    // Start is called before the first frame update
    void Start()
    {
        spawnZoneCenterX = transform.position.x;
        spawnZoneCenterZ = transform.position.z;

        spawnMinX = spawnZoneCenterX - spawnZoneRadius;
        spawnMaxX = spawnZoneCenterX + spawnZoneRadius;
        spawnMinZ = spawnZoneCenterZ - spawnZoneRadius;
        spawnMaxZ = spawnZoneCenterZ + spawnZoneRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if (testFlag == true)
        {
            for (int i = 0; i < numTests; i++)
            {
                SpawnEvent();
            }
            testFlag = false;
        }
    }

    void SpawnEvent()
    {
        bool validLocation = false;
        Vector3 location = Vector3.zero;

        while (validLocation == false) {
            float x = Random.Range(spawnMinX, spawnMaxX);
            float z = Random.Range(spawnMinZ, spawnMaxZ);
            location = new Vector3(x, y, z);
            validLocation = IsValidLocation(location);
        }
        newObject = Instantiate(testObject, location, Quaternion.identity);
        newObject.GetComponent<Animation>().enabled = false;
        newObject.tag = "interactable";
        newObject.AddComponent<BoxCollider>();
        Debug.Log(location);
    }

    // Helper method for making sure new objects to not spawn on top or
    // inside of preexisting objects.
    // Physics.OverlapSphere -> new Unity feature for Lab 5 credit?
    private bool IsValidLocation(Vector3 location)
    {
        Collider[] colliders = Physics.OverlapSphere(location, objectRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("building") || collider.CompareTag("env_object"))
            {
                return false;
            }
        }
        return true;
    }
}
