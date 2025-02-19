using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    [SerializeField] float startingHealth;
    public float currentHealth { get; private set; }
    
    //death animations not implimented, check 11.04 in the youtube video for this 

    private void Awake()
    {
        currentHealth = startingHealth;
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
            //player dead
        }
    }

    
}
