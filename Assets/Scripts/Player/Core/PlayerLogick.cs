using System;
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

    public void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick)
    {
        MoveJoystick = moveJoystick;
        MoveSetupPlayerView(PlayerModel.GetPlayerView(), MoveJoystick);        
     
        ShootJoystick = shootJoystick;
        ShootSystem.Init(PlayerModel.gameObject, ShootJoystick);
    }

    private void MoveSetupPlayerView(PlayerView playerView, VariableJoystick moveJoystick)
    {        
        playerView.GetMovingSystem().Init(playerView.transform, new Vector3(9999f, 0, 0), 0.1f);//магические числа подобранны опытным путем :)
        playerView.GetMovingSystem().Init(playerView.transform, moveJoystick);
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
