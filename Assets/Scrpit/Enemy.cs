using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public Transform[] Waypoints;
    public Transform TargetWaypoint;
    float minDistance = 1f;
    public NavMeshAgent myAgent;
    void Start()
    {
        TargetWaypoint = Waypoints[0];
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, TargetWaypoint.position);
        if (distance <= minDistance)
        {
            TargetWaypoint = Waypoints[Random.Range(0, 4)];
        }
        myAgent.destination = TargetWaypoint.position;
    }
}
