using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float maxInteractableDistance = 100f;
    public Camera cam;
    public GameObject eventSpawner;
    public GameObject explosion;
    private float explosionLife = 2f;
    public int numProblemsSolved; // this is same as shenanigans
    private AudioSource source;
    public AudioClip kaboom;

    // Start is called before the first frame update
    void Start()
    {
        numProblemsSolved = 0;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Interact();
        }
    }

    void Interact()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxInteractableDistance))
        {
            GameObject obj = hit.transform.gameObject;
            string objTag = obj.tag;
            Debug.Log(objTag);
            // Do stuff, make character react w/ text or animation 
            // depending on the tag of the object clicked on?
            if (obj.CompareTag("interactable"))
            {
                Destroy(obj);
                Vector3 location = obj.transform.position;
                numProblemsSolved++;
                Debug.Log(numProblemsSolved);
                Instantiate(explosion, location, Quaternion.identity);
                source.PlayOneShot(kaboom);
                Destroy(explosion, explosionLife);
                eventSpawner.GetComponent<SpawnEvents>().timeToSpawn = true;
            }
        }
    }

}
