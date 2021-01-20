using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    [SerializeField] private MovingSystem MovingSystem;    
    [SerializeField] private float MoveSpeed = 100f;
    [SerializeField] private float MaxSpeed = 300f;
    [SerializeField] private float MinSpeed = 50f;

    private Rigidbody2D Rigidbody2D;   

    private float MoveAmplitude = 4f;
    private Vector3 TopMovePosition;
    private Vector3 BottomMovePosition; 
    
   
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);       

        TopMovePosition = new Vector3(transform.position.x, transform.position.y + MoveAmplitude, transform.position.z);
        BottomMovePosition = new Vector3(transform.position.x, transform.position.y - MoveAmplitude, transform.position.z);
    }
    
    private void Update()
    {
        MoveUpAndDown();        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {   
        }
    }

    private void MoveUpAndDown()
    {
        if(transform.position.y > TopMovePosition.y)
        {
            MovingSystem.DirectionMoveOn(Rigidbody2D, Vector3.down + -Vector3.right, MoveSpeed, MaxSpeed, MinSpeed);           
        }
        if (transform.position.y < BottomMovePosition.y)
        {
            MovingSystem.DirectionMoveOn(Rigidbody2D, -Vector3.down + -Vector3.right, MoveSpeed, MaxSpeed, MinSpeed);            
        }
    }    
}

