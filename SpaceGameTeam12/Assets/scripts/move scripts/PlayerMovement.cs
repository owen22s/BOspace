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
        // Get horizontal and vertical inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f).normalized;

        // Apply movement
        transform.position += movement * speed * Time.deltaTime;

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
            GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpForce, 0f);

            jumpsRemaining--;
        }
    }

    private void Dash(Vector3 direction)
    {
        // Disable dashing during cooldown
        canDash = false;

        // Apply dash velocity
        GetComponent<Rigidbody>().velocity = direction * dashSpeed;

        // Start the dash cooldown
        StartCoroutine(DashCooldown());
    }

    private System.Collections.IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashDuration);

        // Wait for the dash duration
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        yield return new WaitForSeconds(dashCooldown - dashDuration);

        // Enable dashing after cooldown
        canDash = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset jumps when landing on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}
