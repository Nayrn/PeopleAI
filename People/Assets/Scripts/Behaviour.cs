using UnityEngine;
using System.Collections;

public class Behaviour : MonoBehaviour
{
    private Emotions emotion;
    private float distToPlayer;
    private GameObject player;
    private NavMeshAgent thisAgent;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thisAgent = GetComponent<NavMeshAgent>();
	}
	

	void Update ()
    {
        distToPlayer = Vector3.Distance(player.transform.position, this.transform.position);

        if (distToPlayer < 10.0f && this.gameObject.tag == "Hostile")
            Attack();

        if (distToPlayer < 10.0f && this.gameObject.tag == "Neutral")
            Breed();

    }

    private void Attack()
    {
        thisAgent.destination = player.transform.position;
        Debug.Log("I'm attacking");
    }
    
   private void Breed()
    {
        thisAgent.destination = player.transform.position;
        // just create another AI here, player will need Genetics as well
    }

    private void Gather()
    {
        // Put pathFinding in here, something similar to Dijkstra's would be better than A* in this case
    }
}
