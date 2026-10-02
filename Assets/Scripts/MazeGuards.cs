using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MazeGuardAI : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] waypoints;
    public float waitTime = 2f;
    public float patrolSpeed = 3.5f;

    [Header("Vision Settings")]
    public float viewDistance = 10f;
    public float viewAngle = 60f;
    public Light visionLight; // Drag your Spotlight here
    public Color normalColor = Color.white;
    public Color alertColor = Color.red;

    private NavMeshAgent agent;
    private Transform player;
    private int currentWaypointIndex;
    private bool isWaiting;
    private float waitTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = patrolSpeed;
        
        if (waypoints.Length > 0)
            SetNextDestination();
    }

    void Update()
    {
        // 1. Always check for the player
        if (CanSeePlayer())
        {
            visionLight.color = alertColor;
            // Pass this specific enemy's AudioSource to the manager
            FindObjectOfType<GameFlowManager>().PlayerCaught(GetComponent<AudioSource>());
        }

        else
        {
            visionLight.color = normalColor;
        }

        // 2. Patrolling & Waiting Logic
        if (!isWaiting && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartWaiting();
        }

        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                isWaiting = false;
                SetNextDestination();
            }
        }
    }

    void StartWaiting()
    {
        isWaiting = true;
        waitTimer = waitTime;
        agent.isStopped = true; // Stop moving
    }

    void SetNextDestination()
    {
        agent.isStopped = false;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    bool CanSeePlayer()
    {
        Vector3 dirToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, dirToPlayer);

        if (angle < viewAngle / 2f && dirToPlayer.magnitude <= viewDistance)
        {
            // Raycast check to ensure no walls are in the way
            if (Physics.Raycast(transform.position, dirToPlayer.normalized, out RaycastHit hit, viewDistance))
            {
                if (hit.collider.CompareTag("Player")) return true;
            }
        }
        return false;
    }

    void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

