using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_rb;
    public float m_fSpeed;

    // Use this for initialization
    void Start ()
    {
        m_rb = GetComponent<Rigidbody>();
        m_fSpeed = 5.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {


    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        m_rb.velocity = movement * m_fSpeed;

        // camera movement

    }
}
