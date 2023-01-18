using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;
    private int currentPoint = 0;
    private bool goingRight = true;

    void Update()
    {
        if (transform.position == patrolPoints[currentPoint].position)
        {
            if (goingRight)
            {
                currentPoint++;
                if (currentPoint >= patrolPoints.Length)
                {
                    currentPoint = patrolPoints.Length - 2;
                    goingRight = false;
                }
            }
            else
            {
                currentPoint--;
                if (currentPoint < 0)
                {
                    currentPoint = 1;
                    goingRight = true;
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = Checkpoint.SpawnPoint;
        }
    }
}
