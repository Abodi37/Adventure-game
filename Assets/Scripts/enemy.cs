using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent myEnemy;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 5f)
        {
            myEnemy.SetDestination(player.position);
        }
    }
}
