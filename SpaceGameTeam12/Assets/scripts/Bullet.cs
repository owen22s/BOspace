using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2;

    private void Start()
    {
        // Destroy the bullet after the specified lifetime
        Destroy(gameObject, lifetime);
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f);

    }

    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject); // Destroy the bullet as well if it hits an enemy
        }
        if (other.gameObject.CompareTag("StrongEnemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject); // Destroy the bullet as well if it hits an enemy
        }
    }
}

