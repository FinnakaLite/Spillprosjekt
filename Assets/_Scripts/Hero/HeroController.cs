using UnityEngine;

public class HeroController : MonoBehaviour
{
    private SpriteRenderer sr;
    private float moveSpeed = 2.75f; // Adjusted speed for platformer
    private Rigidbody2D body;
    private Animator animator;

    // Jumping variables
    public float jumpForce = 10f; // Force applied when jumping
    private bool isGrounded; // Check if the hero is on the ground
    public Transform groundCheck; // Position to check if the hero is grounded
    public float groundCheckRadius = 0.2f; // Radius for ground check
    public LayerMask groundLayer; // Layer to identify ground
    public DialogueBoxUIController dialogueBoxController;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity =
            new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y); // Maintain vertical velocity for jumping

        // Sprite Renderer Logic
        if (horizontalInput > 0)
        {
            sr.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            sr.flipX = true;
        }

        // Animation Logic
        animator.SetBool("isMoving", horizontalInput != 0);

        // Jumping Logic
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && Input.GetButtonDown("Jump")) // Check if grounded and jump button is pressed
        {
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        
    }

    private void OnDrawGizmos()
    {
        // Visualize the ground check area in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}