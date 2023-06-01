using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform spawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.transform.position = spawnPoint.position;
        }
    }
}

