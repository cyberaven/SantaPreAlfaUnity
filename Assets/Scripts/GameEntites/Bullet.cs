using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private MovingSystem MovingSystem;
    private Rigidbody2D Rigidbody2D;
    private float MoveSpeed = 300f;
   
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);        
    }
    
    public void MoveAway(Vector3 startPosition, Vector3 direction)
    {
        transform.position = startPosition;
        MovingSystem.DirectionMoveOn(Rigidbody2D, direction);               
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "House")
        {
            Die();
        }
        if(collision.tag == "Lamppost")
        {
            LampCollision(collision);
        }
        if (collision.tag == "Virus")
        {
            Die();
        }
    }

    private void LampCollision(Collider2D collision)
    {
        Lamppost l = collision.gameObject.GetComponent<Lamppost>();
        int lampHealth = l.GetHealth();

        if (lampHealth > 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public MovingSystem GetMovingSystem()
    {
        return MovingSystem;
    }
}
