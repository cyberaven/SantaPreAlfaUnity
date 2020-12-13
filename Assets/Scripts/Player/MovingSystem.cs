using UnityEngine;
using System.Collections;
using System;

public class MovingSystem : MonoBehaviour
{    
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    private VariableJoystick MoveJoystick;
    private Transform Transform;

    private float rbDirectionMoveSpeed = 10f;
    public float RbDirectionMoveSpeed { get => rbDirectionMoveSpeed;}

    private float rbJoystickMoveSpeed = 10f;
    public float RbJoystickMoveSpeed { get => rbJoystickMoveSpeed; }

    private float trDirectionMoveSpeed = 10f;
    public float TrDirectionMoveSpeed { get => trDirectionMoveSpeed; }

    private float trJoystickMoveSpeed = 10f;
    public float TrJoystickMoveSpeed { get => trJoystickMoveSpeed; }

    [SerializeField] private string curentSpeed = "::NULLCurntSpeed::";
    public string CurentSpeed { get => curentSpeed; set => curentSpeed = value; }


    private float MaxSpeed = 20f;

    

    private void FixedUpdate()
    {        
        Move();
        CheckMaxSpeed();        
    }

    
    public void Init(Rigidbody2D rigidbody2D, VariableJoystick variableJoystick, float moveSpeed = 10f)
    {
        Rigidbody2D = rigidbody2D;
        MoveJoystick = variableJoystick;
        rbJoystickMoveSpeed = moveSpeed;
    }
    public void Init(Rigidbody2D rigidbody2D, Vector3 direction, float moveSpeed = 10f)
    {
        Rigidbody2D = rigidbody2D;
        Direction = direction;
        rbDirectionMoveSpeed = moveSpeed;
    }
    public void Init(Transform transform, VariableJoystick variableJoystick, float moveSpeed = 10f)
    {
        Transform = transform;
        MoveJoystick = variableJoystick;
        trJoystickMoveSpeed = moveSpeed;
    }
    public void Init(Transform transform, Vector3 direction, float moveSpeed = 10f)
    {
        Transform = transform;
        Direction = direction;
        trDirectionMoveSpeed = moveSpeed;
    }

    private void Move()
    {
        if (Rigidbody2D != null && MoveJoystick != null)
        {
            Vector3 direction = GetDirection(MoveJoystick);
            Rigidbody2D.AddForce(direction * RbJoystickMoveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }        
        if(Rigidbody2D != null && Direction != null)
        {
            Rigidbody2D.AddForce(Direction * RbDirectionMoveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        if (Transform != null && MoveJoystick != null)
        {            
            Vector3 direction = GetDirection(MoveJoystick);
            Transform.position += direction * TrJoystickMoveSpeed;                      
        }
        if (Transform != null && Direction != null)
        {            
            Transform.position = Vector3.MoveTowards(transform.position, Direction, Time.fixedDeltaTime * TrDirectionMoveSpeed);            
        }
    }
    private void CheckMaxSpeed()
    {
        if (Rigidbody2D != null)
        {             
            curentSpeed = Rigidbody2D.velocity.sqrMagnitude.ToString();
            if (Rigidbody2D.velocity.sqrMagnitude > MaxSpeed)
            {
                Rigidbody2D.velocity *= 0.99f;
            }
        }
        else
        {
            //тут ограничитель скорости для transform
        }
    }
    private Vector3 GetDirection(VariableJoystick moveJoystick)
    {
        Vector3 direction = Vector3.up * moveJoystick.Vertical + Vector3.right * moveJoystick.Horizontal;
        return direction;
    }
}
