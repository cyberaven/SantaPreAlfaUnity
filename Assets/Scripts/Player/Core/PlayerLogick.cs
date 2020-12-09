﻿using System;
using System.Collections;
using UnityEngine;


public class PlayerLogick : MonoBehaviour
{
    private PlayerModel PlayerModel;

    private VariableJoystick MoveJoystick;
    private VariableJoystick ShootJoystick;

    [SerializeField] private ShootSystem ShootSystem;
    
    private void Awake()
    {   
        ShootSystem = Instantiate(ShootSystem, transform);
    }
    private void Update()
    {
        PlayerModelChangeMoveSpeed();               
    }

    private void PlayerModelChangeMoveSpeed()
    {
        Vector3 viewCurrentPos = PlayerModel.GetPlayerView().GetLocalPosition();
        Vector3 startPos = PlayerModel.GetViewStartPosition().localPosition;
        float distance = 0;

        if (viewCurrentPos.x > startPos.x)
        {           
            distance = (startPos.x * -1) - (viewCurrentPos.x * -1);            
        }
        if (viewCurrentPos.x < startPos.x)
        {
            distance = (viewCurrentPos.x * -1) - (startPos.x * -1);
            distance *= -1f;
        }
        
        PlayerModel.ChangeMoveSpeed(distance * 0.01f);
    }

    public void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick)
    {
        MoveJoystick = moveJoystick;
        MoveSetupPlayerView(PlayerModel.GetPlayerView(), MoveJoystick);        
     
        ShootJoystick = shootJoystick;
        ShootSystem.Init(PlayerModel.gameObject, ShootJoystick);
    }

    private void MoveSetupPlayerView(PlayerView playerView, VariableJoystick moveJoystick)
    { 
       playerView.GetMovingSystem().Init(playerView.GetRigidbody2D(), moveJoystick, 1000f);
    }

    public VariableJoystick GetShootingJoystick()
    {
        return ShootJoystick;
    }
    public VariableJoystick GetMovingJoystick()
    {
        return MoveJoystick;
    }    
    public void SetPlayerModel(PlayerModel playerModel)
    {
        PlayerModel = playerModel;
    }
}