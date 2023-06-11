using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Raycast : MonoBehaviour
{
    public GameObject inGameSection;

    public GameObject spawn_prefabs;
    public GameObject spawned_object;

    public bool object_spawned;

    public ARRaycastManager arr;

    public List <ARRaycastHit> hits = new List <ARRaycastHit>();

    public Pose fixedPose;

    // Start is called before the first frame update
    void Start()
    {
        object_spawned = false;

        arr = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inGameSection.activeSelf)
        {
            // Check touch input from screen
            if (Input.touchCount > 0)
            {
                if (arr.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;

                    // Check if object is already spawnned
                    if (!object_spawned)
                    {
                        // Rotate object
                        hitPose.rotation.y = 180;

                        // Render object
                        spawned_object = Instantiate(spawn_prefabs, hitPose.position, hitPose.rotation);
                        object_spawned = true;

                        fixedPose = hitPose;
                    }
                }
            }
        }
    }
}
