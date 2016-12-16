using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    public GameObject resource;
    public int resourceTotal;
    private int resourceCap;
    // Use this for initialization
    void Start ()
    {

        resourceTotal = 0;
        resourceCap = 30;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(resourceTotal < resourceCap)
            spawnResource();
        // get rid of destroying and random respawning
    }

    void spawnResource()
    {

        float randX = Random.Range(16, 400);
        float randZ = Random.Range(10, 400);
        Vector3 resPos = new Vector3(randX, 0.9f, randZ);
        Debug.Log(resPos);
        Instantiate(resource, resPos, resource.transform.rotation);
        resourceTotal = resourceTotal + 1;       
    }
}
