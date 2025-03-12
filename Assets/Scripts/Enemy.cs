using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public List<Transform> waypoints;
    public int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Walking();   
    }

    void Walking()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        float distanceToWayPoint = Vector3.Distance(waypoints[waypointIndex].position, transform.position);
        
        if (distanceToWayPoint <= 1)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Count;
        }

        agent.SetDestination(waypoints[waypointIndex].position);
    }
}
