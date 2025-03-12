using UnityEngine;

public class FlipAxis : MonoBehaviour
{
    private SpriteRenderer sr; // Reference to the Sprite Renderer
    private Enemy_UpDown enemyUpDown; // Reference to the Enemy_UpDown script

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>(); // Get the Sprite Renderer component
        enemyUpDown = GetComponent<Enemy_UpDown>(); // Get the Enemy_UpDown component
    }

    private void Update()
    {
        // Check if the Enemy_UpDown script is available
        if (enemyUpDown != null)
        {
            // Flip the sprite based on the movement direction
            sr.flipY = enemyUpDown.IsMovingUp(); // Flip the sprite if moving down
        }
    }
}