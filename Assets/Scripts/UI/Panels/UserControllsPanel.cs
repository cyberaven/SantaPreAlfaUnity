using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControllsPanel : Panel
{
    [SerializeField] private VariableJoystick MoveJoystick;
    [SerializeField] private VariableJoystick ShootJoystick;
    
    private void Start()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
        PlayerCreator.PlayerCreatedEve += PlayerCreated;
        Hide();
    }

    private void PlayerCreated(PlayerModel player)
    {
        player.SetControllers(MoveJoystick, ShootJoystick);
    }

    private void LevelCreated(Level level)
    {
        Show();
    }
}
