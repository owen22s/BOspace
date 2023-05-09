using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 200f; // The speed at which the player moves

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
        rb.velocity = movement * moveSpeed;
    }
}

