using System.Collections;
using UnityEngine;

public class DirectionMoveData : MoveData
{
    public DirectionMoveData(Rigidbody2D rigidbody2D, Vector3 direction, float moveSpeed = 10f, float maxSpeed = 20f, float minSpeed = 10f)
        : base(rigidbody2D, moveSpeed, maxSpeed, minSpeed)
    {
        Direction = direction;
    }
    public Vector3 Direction { get; }
}