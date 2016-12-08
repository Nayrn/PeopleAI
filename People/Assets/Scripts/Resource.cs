using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
    private bool isColliding;
    public GameObject resource;
	// Use this for initialization
	void Start ()
    {
        isColliding = false;
        for (int i = 0; i < 2; i++)
            spawnResource(i);

    }
	
	// Update is called once per frame
	void Update ()
    {

     
        // Scaling down on collision
        if (isColliding)
        {
            Vector3 scaleX = new Vector3(-1, 0, 0);
            Vector3 scaleY = new Vector3(0, -1, 0);
            this.gameObject.transform.localScale += scaleX * Time.deltaTime / 2;
            this.gameObject.transform.localScale += scaleY * Time.deltaTime / 2;
            if (this.gameObject.transform.localScale.x < 0.3f)
                this.gameObject.SetActive(false);
        }

	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
            isColliding = true;
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
            isColliding = false;
    }

    void spawnResource(int amount)
    {

        Vector3 resPos = new Vector3(Random.insideUnitSphere.x, 0.9f, Random.insideUnitSphere.z);
        Instantiate(resource, resPos, resource.transform.rotation);
    }
}
