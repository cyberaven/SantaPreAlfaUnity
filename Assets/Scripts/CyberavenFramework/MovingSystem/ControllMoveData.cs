using System.Collections;
using UnityEngine;

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
