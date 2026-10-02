using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float viewDistance = 10f;
    public float viewAngle = 45f;
    public Transform myPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (myPlayer == null)
        {
            myPlayer = GameObject.FindGameObjectWithTag("player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the enemy to watch the area 
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        //check if player in sight

    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = myPlayer.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
        
        // check if player is within the view cone angle and distance
        if (angleToPlayer < viewAngle && directionToPlayer.magnitude < viewDistance)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer.normalized, out hit, viewDistance))
            {
                if (hit.collider.CompareTag("player"))
                {
                    return true;
                }
            }
        }
        return false;
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
