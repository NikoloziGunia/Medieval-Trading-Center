using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed at which the player moves
    public float rotationSpeed = 200f;  // Speed at which the player rotates

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Get input values for horizontal and vertical axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normalize the movement vector to maintain consistent speed in all directions
        movement = movement.normalized;

        // Apply the movement to the rigidbody if there is input
        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

            // Rotate the player based on movement direction
            float angle = Mathf.Round(Mathf.Atan2(-movement.y, -movement.x) * Mathf.Rad2Deg / 180f) * 180f;
            Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}