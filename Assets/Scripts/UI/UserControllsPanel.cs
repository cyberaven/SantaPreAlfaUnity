using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControllsPanel : Panel
{
    [SerializeField] private VariableJoystick MoveJoystick;
    [SerializeField] private VariableJoystick ShootJoystick;

    private void Awake()
    {
        Player.PlayerCreatedEve += PlayerCreated;
        Hide();
    }

    private void PlayerCreated(Player player)
    {
        Show();
        player.SetControllers(MoveJoystick, ShootJoystick);
    }
}
