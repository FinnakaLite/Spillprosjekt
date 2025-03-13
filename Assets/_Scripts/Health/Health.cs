using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    [SerializeField] float startingHealth;
    public float currentHealth { get; private set; }

    public bool deathStatus;
    
    //death animations not implimented, check 11.04 in the youtube video for this 

    private void Awake()
    {
        currentHealth = startingHealth;
        deathStatus = false;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //player is hurt
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        // Find the GameObject with the GameController script
        GameObject gameControllerObject = GameObject.Find("GameController"); // Or use a public GameObject variable assigned in the Inspector
        if (gameControllerObject != null)
        {
            // Get the GameController component
            GameController gameController = gameControllerObject.GetComponent<GameController>();
            if (gameController != null)
            {
                // Call the Death function
                gameController.Death();
            }
            else
            {
                Debug.LogError("GameController component not found on GameController GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameController GameObject not found.");
        }
    }
}
