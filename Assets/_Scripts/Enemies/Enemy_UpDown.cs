using System;
using UnityEngine;

public class Enemy_UpDown : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float movementDistance;
    [SerializeField] private float speed;
    private bool movingUp;
    private float upEdge;
    private float downEdge;

    private void Awake()
    {
        upEdge = transform.position.y + movementDistance; 
        downEdge = transform.position.y - movementDistance; 
    }

    private void Update()
    {
        if (movingUp)
        {
            if (transform.position.y < upEdge) 
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (transform.position.y > downEdge) 
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z); 
            }
            else
            {
                movingUp = true;
            }
        }
    }
    
    // Public method to check if the object is moving up
    public bool IsMovingUp()
    {
        return movingUp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}