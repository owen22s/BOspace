using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Move the player object to the spawn point
            other.transform.position = spawnPoint.position;
        }
    }
}

