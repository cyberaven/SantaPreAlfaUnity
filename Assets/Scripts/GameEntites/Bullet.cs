using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private float MoveSpeed = 1000f;
    
    private Vector3 MoveDirection = Vector3.zero;
    private Vector3 StartPosition = Vector3.zero;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void MoveAway(Vector3 startPosition, Vector3 direction)
    {
        StartPosition = startPosition;
        MoveDirection = direction;

        transform.position = StartPosition;
        Rigidbody2D.AddForce(MoveDirection * MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
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
}
