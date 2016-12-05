﻿using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
    private bool isColliding;

	// Use this for initialization
	void Start ()
    {
        isColliding = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // move this to collision code, on collision with player or AI
        if(isColliding)
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
}