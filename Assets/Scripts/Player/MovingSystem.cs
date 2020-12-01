using UnityEngine;
using System.Collections;
using System;

public class MovingSystem : MonoBehaviour
{    
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    private VariableJoystick MoveJoystick;
    private Transform Transform;

    private float MoveSpeed = 50f;
    private float MaxSpeed = 50f;

    private void FixedUpdate()
    {
        Move();
       // CheckMaxSpeed();
    }    

    public void Init(Rigidbody2D rigidbody2D, VariableJoystick variableJoystick)
    {
        Rigidbody2D = rigidbody2D;
        MoveJoystick = variableJoystick;
    }
    public void Init(Rigidbody2D rigidbody2D, Vector3 direction)
    {
        Rigidbody2D = rigidbody2D;
        Direction = direction;        
    }
    public void Init(Transform transform, VariableJoystick variableJoystick, float moveSpeed = 0f)
    {
        Transform = transform;
        MoveJoystick = variableJoystick;
        if (moveSpeed != 0f)
        {
            MoveSpeed = moveSpeed;
        }
    }
    public void Init(Transform transform, Vector3 direction, float moveSpeed = 0f)
    {
        Transform = transform;
        Direction = direction;
        if(moveSpeed != 0f)
        {
            MoveSpeed = moveSpeed;
        }
    }

    private void Move()
    {
        if (Rigidbody2D != null && MoveJoystick != null)
        {
            Vector3 direction = GetDirection(MoveJoystick);
            Rigidbody2D.AddForce(direction * MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);            
        }        
        if(Rigidbody2D != null && Direction != null)
        {
            Rigidbody2D.AddForce(Direction * MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        if (Transform != null && MoveJoystick != null)
        {            
            Vector3 direction = GetDirection(MoveJoystick);
            if (direction != Vector3.zero)
            {
                Transform.position += direction;
            }            
        }
        if (Transform != null && Direction != null)
        {            
            Transform.position = Vector3.MoveTowards(transform.position, Direction, Time.fixedDeltaTime * MoveSpeed);
        }
    }
    private void CheckMaxSpeed()
    {
        if (Rigidbody2D.velocity.sqrMagnitude > MaxSpeed)
        {
            Rigidbody2D.velocity *= 0.99f;
        }
    }
    private Vector3 GetDirection(VariableJoystick moveJoystick)
    {
        Vector3 direction = Vector3.up * moveJoystick.Vertical + Vector3.right * moveJoystick.Horizontal;
        return direction;
    }
}
