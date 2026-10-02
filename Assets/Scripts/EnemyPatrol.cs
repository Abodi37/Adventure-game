using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints;  // Drag your Waypoint objects here in the Inspector
    private int currentWaypointIndex = 0;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint();
    }

    void Update()
    {
        // Check if the agent has reached the waypoint
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            GoToNextWaypoint();
        }
    }
    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

         // Set the destination to the current waypoint
        navMeshAgent.destination = waypoints[currentWaypointIndex].position;

         // Cycle to the next point, looping back to the first if necessary
        //currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        // the enemy goes to random points 
        currentWaypointIndex = Random.Range(0, waypoints.Length);


    }
}
