using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{

    private float xSpeed = 0.5f;
    private float ySpeed = 0.5f;
    public GameObject player;
    public float distToPlayerX;
    public float distToPlayerY;
    public float distToPlayerZ;


    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	

	void Update ()
    {
        float x = xSpeed * Input.GetAxis("Mouse X");
        float y = ySpeed * Input.GetAxis("Mouse Y");

        transform.Translate(x, y, 0);

        // find a way to properly clamp camera bounds

                 
    }
}
