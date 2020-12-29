using System.Collections;
using UnityEngine;

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
    public float MoveSpeed { get; private set; }
    public float MaxSpeed { get; private set; }
    public float MinSpeed { get; private set; }
    public float CurrentSpeed
    {
        get
        {
            return Rigidbody2D.velocity.sqrMagnitude;
        }
    }
    public void CheckMaxSpeed()
    {
        if (CurrentSpeed > MaxSpeed * MaxSpeed)
        {
            Rigidbody2D.velocity *= 0.99f;
        }
    }
    public void CheckMinSpeed()
    {
        if (CurrentSpeed < MinSpeed * MinSpeed)
        {
            Rigidbody2D.velocity *= 1.05f;
        }
    }
    public void Stop()
    {
        Rigidbody2D.velocity = Vector2.zero;
    }
    public void ChangeMoveSpeed(float newMoveSpeed)
    {
        MoveSpeed = newMoveSpeed;
    }
}