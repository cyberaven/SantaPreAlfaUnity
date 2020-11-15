using UnityEngine;
using System.Collections;


public interface IPlayer
{
    GameObject GetGameObject();
    void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick);
    Rigidbody2D GetRigidbody2D();
    VariableJoystick GetMovingJoystick();
    VariableJoystick GetShootingJoystick();

}
