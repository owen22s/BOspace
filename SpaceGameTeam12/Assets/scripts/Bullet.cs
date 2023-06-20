using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2;

    private void Start()
    {
        // Destroy the bullet after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collided with an object tagged as an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject); // Destroy the bullet as well if it hits an enemy
        }
    }
}

