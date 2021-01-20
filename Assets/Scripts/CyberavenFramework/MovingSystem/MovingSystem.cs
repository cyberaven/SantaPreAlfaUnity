using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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


    private void FixedUpdate()
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
            Vector3 direction = ControllMoveData.GetDirection();
            
            if(direction == Vector3.zero)
            {
                ControllMoveData.Stop();
            }
            else
            {
                ControllMoveData.Rigidbody2D.velocity = direction * ControllMoveData.MoveSpeed * Time.fixedDeltaTime;
            }
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
            DirectionMoveData.Rigidbody2D.velocity = DirectionMoveData.Direction * DirectionMoveData.MoveSpeed * Time.fixedDeltaTime;
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
        if (DirectionMoveEnable)
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