using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isJumping;
    private bool isGrounded;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        Vector2 movement = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        rb.velocity = movement;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            // Implement shooting logic here
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if (isJumping && isGrounded)
        {
            isJumping = false;
        }
    }

    private void Shoot()
    {
        // Implement shooting logic here
        // For example, instantiate a projectile object and apply force in the desired direction
    }
}