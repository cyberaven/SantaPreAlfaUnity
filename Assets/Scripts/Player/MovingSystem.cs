using UnityEngine;
using System.Collections;
using System;

public class MovingSystem : MonoBehaviour
{    
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    private VariableJoystick MoveJoystick;
    private Transform Transform;

    [SerializeField] private float MoveSpeed = 1000f;
    [SerializeField] private float MaxSpeed = 100f;

    private void FixedUpdate()
    {
        Move();
        CheckMaxSpeed();
    }

    private void CheckMaxSpeed()
    {
        if (Rigidbody2D.velocity.sqrMagnitude > MaxSpeed)
        {
            Rigidbody2D.velocity *= 0.99f;
        }
    }

    public void Init(Rigidbody2D rigidbody2D, VariableJoystick variableJoystick)
    {
        Rigidbody2D = rigidbody2D;
        MoveJoystick = variableJoystick;
    }
    public void Init(Rigidbody2D rigidbody2D, Vector3 direction, float moveSpeed = 1000f)
    {
        Rigidbody2D = rigidbody2D;
        Direction = direction;
        MoveSpeed = moveSpeed;        
    }
    public void Init(Transform transform, VariableJoystick variableJoystick)
    {
        Transform = transform;
        MoveJoystick = variableJoystick;
    }


    private void Move()
    {
        if (Rigidbody2D != null && MoveJoystick != null)
        {
            Vector3 direction = GetDirection(MoveJoystick);
            Rigidbody2D.AddForce(direction * MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);            
        }
        if(Transform != null && MoveJoystick != null)
        {
            Vector3 direction = GetDirection(MoveJoystick);
            Transform.position = Vector3.MoveTowards(transform.position, direction, Time.fixedDeltaTime * MoveSpeed);
        }
        if(Rigidbody2D != null && Direction != null)
        {
            Rigidbody2D.AddForce(Direction * MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }        
    }

    private Vector3 GetDirection(VariableJoystick moveJoystick)
    {
        Vector3 direction = new Vector3();

        if (MoveJoystick.Vertical > 0.1f || MoveJoystick.Vertical < -0.1f || MoveJoystick.Horizontal > 0.1f || MoveJoystick.Horizontal < -0.1f)
        {
            direction = Vector3.up * MoveJoystick.Vertical + Vector3.right * MoveJoystick.Horizontal;
        }

        return direction;
    }
}
