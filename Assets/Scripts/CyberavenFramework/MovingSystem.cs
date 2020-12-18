using UnityEngine;
using System.Collections;
using System;

public class MovingSystem : MonoBehaviour
{      
    [Header("ControllMoveData")]    
    [SerializeField] private float ControllMoveCurrentSpeed = 0;
    [SerializeField] private float ControllMoveMaxSpeedLimit = 0;
    [SerializeField] private float ControllMoveMinSpeedLimit = 0;
    private ControllMoveData ControllMoveData = null;
    private bool ControllMoveEnable = false;
    [Space]
    [Header("DirectionMoveData")]
    [SerializeField] private float DirectionMoveCurrentSpeed = 0;
    [SerializeField] private float DirectionMoveMaxSpeedLimit = 0;
    [SerializeField] private float DirectionMoveMinSpeedLimit = 0;
    private DirectionMoveData DirectionMoveData = null;
    private bool DirectionMoveEnable = false;


    private void Update()
    {
        ControllMove();
        DirectionMove();
        CheckMaxSpeed();
        CheckMinSpeed();
        ShowCurrentSpeedAndLimit();       
    }

    
    public void ControllMoveOn(Rigidbody2D rigidbody2D, VariableJoystick variableJoystick, float moveSpeed = 10f, float maxSpeed = 20f, float minSpeed = 10f)
    {
        ControllMoveData = new ControllMoveData(rigidbody2D, variableJoystick, moveSpeed, maxSpeed, minSpeed);
        ControllMoveEnable = true;
    }
    public void ControllMoveOff()
    {
        ControllMoveEnable = false;
    }
    private void ControllMove()
    {
        if(ControllMoveEnable == true)
        {            
            ControllMoveData.Rigidbody2D.AddForce(ControllMoveData.GetDirection() * ControllMoveData.MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    public void DirectionMoveOn(Rigidbody2D rigidbody2D, Vector3 direction, float moveSpeed = 10f, float maxSpeed = 20f, float minSpeed = 10f)
    {
        DirectionMoveData = new DirectionMoveData(rigidbody2D, direction, moveSpeed, maxSpeed, minSpeed);
        DirectionMoveEnable = true;
    }
    public void DirectionMoveOff()
    {
        DirectionMoveEnable = false;
    }
    private void DirectionMove()
    {
        if(DirectionMoveEnable == true)
        {
            DirectionMoveData.Rigidbody2D.AddForce(DirectionMoveData.Direction * DirectionMoveData.MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    private void ShowCurrentSpeedAndLimit()
    {
        if(ControllMoveEnable)
        {
            ControllMoveCurrentSpeed = ControllMoveData.CurrentSpeed;
            ControllMoveMaxSpeedLimit = ControllMoveData.MaxSpeed;
            ControllMoveMinSpeedLimit = ControllMoveData.MinSpeed;
        }
        if(DirectionMoveEnable)
        {
            DirectionMoveCurrentSpeed = DirectionMoveData.CurrentSpeed;
            DirectionMoveMaxSpeedLimit = DirectionMoveData.MaxSpeed;
            DirectionMoveMinSpeedLimit = DirectionMoveData.MinSpeed;
        }           
    }

    private void CheckMaxSpeed()
    {
        if (ControllMoveEnable)
        {
            ControllMoveData.CheckMaxSpeed();
        }
        if(DirectionMoveEnable)
        {
            DirectionMoveData.CheckMaxSpeed();
        }
    }
    private void CheckMinSpeed()
    {
        if (ControllMoveEnable)
        {
            ControllMoveData.CheckMinSpeed();
        }
        if (DirectionMoveEnable)
        {
            DirectionMoveData.CheckMinSpeed();
        }
    }   
}

public class ControllMoveData : MoveData
{
    public ControllMoveData(Rigidbody2D rigidbody2D, VariableJoystick variableJoystick, float moveSpeed = 10f, float maxSpeed = 20f, float minSpeed = 10f)
        : base(rigidbody2D, moveSpeed, maxSpeed, minSpeed)
    {            
        VariableJoystick = variableJoystick;       
    }    
    public VariableJoystick VariableJoystick { get; }
    public Vector3 GetDirection()
    {
        Vector3 direction = Vector3.up * VariableJoystick.Vertical + Vector3.right * VariableJoystick.Horizontal;
        return direction;
    }
}
public class DirectionMoveData : MoveData
{
    public DirectionMoveData(Rigidbody2D rigidbody2D, Vector3 direction, float moveSpeed = 10f, float maxSpeed = 20f, float minSpeed = 10f)
        : base(rigidbody2D, moveSpeed, maxSpeed, minSpeed)
    {
        Direction = direction;
    }
    public Vector3 Direction { get; }
}

public class MoveData
{
    public MoveData(Rigidbody2D rigidbody2D, float moveSpeed = 10f, float maxSpeed = 20f, float minSpeed = 10f)
    {
        Rigidbody2D = rigidbody2D;        
        MoveSpeed = moveSpeed;
        MaxSpeed = maxSpeed;
        MinSpeed = minSpeed;
    }
    public Rigidbody2D Rigidbody2D { get; }   
    public float MoveSpeed { get; }
    public float MaxSpeed { get; }
    public float MinSpeed { get; }
    public float CurrentSpeed
    {
        get
        {
            return Rigidbody2D.velocity.sqrMagnitude;
        }
    }
    public void CheckMaxSpeed()
    {
        if(CurrentSpeed > MaxSpeed * MaxSpeed)
        {
            Rigidbody2D.velocity *= 0.95f;
        }
    }
    public void CheckMinSpeed()
    {
        if(CurrentSpeed < MinSpeed * MinSpeed)
        {
            Rigidbody2D.velocity *= 1.05f;
        }
    }
}