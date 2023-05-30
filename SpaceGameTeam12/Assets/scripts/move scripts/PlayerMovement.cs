using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public int maxJumps = 2;
    private int jumpsRemaining;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;
    private bool canDash = true;

    private void Start()
    {
        jumpsRemaining = maxJumps;
    }

    private void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, 0f).normalized;

        // Apply movement
        transform.position += new Vector3(movement.x, movement.y, 0f) * speed * Time.deltaTime;

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check for dash input
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Dash(movement);
        }
    }

    private void Jump()
    {
        if (jumpsRemaining > 0)
        {
            // Perform the jump action
            float jumpForce = 5f;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, jumpForce);
            GetComponent<AudioSource>().Play();

            jumpsRemaining--;
        }
    }

    private void Dash(Vector2 direction)
    {
        // Disable dashing during cooldown
        canDash = false;

        // Apply dash velocity
        GetComponent<Rigidbody2D>().velocity = direction * dashSpeed;

        // Start the dash cooldown
        StartCoroutine(DashCooldown());
    }

    private System.Collections.IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashDuration);

        // Wait for the dash duration
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        yield return new WaitForSeconds(dashCooldown - dashDuration);

        // Enable dashing after cooldown
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jumps when landing on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}
