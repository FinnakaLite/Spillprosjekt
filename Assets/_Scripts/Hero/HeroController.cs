using UnityEngine;

public class HeroController : MonoBehaviour
{
    private SpriteRenderer sr;
    private float moveSpeed = 1;
    private Rigidbody2D body;
    

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        body.linearVelocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);
        

        if (horizontalInput > 0)
        {
            sr.flipX = false;
        }
        
        else if (horizontalInput < 0)
        {
            sr.flipX = true;
        }
    }
}
