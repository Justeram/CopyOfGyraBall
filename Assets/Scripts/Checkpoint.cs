using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Vector3 spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawnPoint = transform.position;
        }
    }

    public static Vector3 SpawnPoint
    {
        get { return spawnPoint; }
    }
}
