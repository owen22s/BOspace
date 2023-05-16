using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Get horizontal and vertical inputs
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 2f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1f;
        }

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Apply movement
        transform.position += movement * speed * Time.deltaTime;
    }
}
