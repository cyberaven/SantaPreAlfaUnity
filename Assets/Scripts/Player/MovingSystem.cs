﻿using UnityEngine;
using System.Collections;


public class MovingSystem : MonoBehaviour
{    
    private Rigidbody2D Rigidbody2D;
    private VariableJoystick MoveJoystick;    

    [SerializeField] private float MoveSpeed = 1000f;

    private void FixedUpdate()
    {
        Move();
    }

    public void Init(Rigidbody2D rigidbody2D, VariableJoystick variableJoystick)
    {
        Rigidbody2D = rigidbody2D;
        MoveJoystick = variableJoystick;
    }
    private void Move()
    {
        if (MoveJoystick.Vertical > 0.1f || MoveJoystick.Vertical < -0.1f || MoveJoystick.Horizontal > 0.1f || MoveJoystick.Horizontal < -0.1f)
        {
            Vector3 direction = Vector3.up * MoveJoystick.Vertical + Vector3.right * MoveJoystick.Horizontal;
            Rigidbody2D.AddForce(direction * MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
}
