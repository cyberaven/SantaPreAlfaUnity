using System;
using System.Collections;
using UnityEngine;


public class PlayerLogick : MonoBehaviour
{
    private PlayerModel PlayerModel;

    private VariableJoystick MoveJoystick;
    
    private VariableJoystick ShootJoystick;
    [SerializeField] private ShootSystem ShootSystem;
    [SerializeField] private float ShootJoystickActionLimiter = 0.2f;

    #region Unity Method
    private void OnEnable()
    {
        DropBombButton.DropBombButtonClkEve += DropBombButtonClk;
    }
    private void OnDisable()
    {
        DropBombButton.DropBombButtonClkEve -= DropBombButtonClk;
    }
    private void Awake()
    {   
        ShootSystem = Instantiate(ShootSystem, transform);
    }
    private void Update()
    {
        PlayerModelChangeMoveSpeed();
        CheckShootJoystick();
    }
    #endregion

    private void CheckShootJoystick()
    {
        if (ShootJoystick.Vertical > ShootJoystickActionLimiter || ShootJoystick.Vertical < -ShootJoystickActionLimiter || ShootJoystick.Horizontal > ShootJoystickActionLimiter || ShootJoystick.Horizontal < -ShootJoystickActionLimiter)
        {
            Vector3 direction = Vector3.up * ShootJoystick.Vertical + Vector3.right * ShootJoystick.Horizontal;
            ShootSystem.Shoot(EProjectileType.Bullet, direction);
        }
    }
    private void DropBombButtonClk()
    {
        ShootSystem.Shoot(EProjectileType.Bomb, -PlayerModel.transform.up);
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
       playerView.GetMovingSystem().Init(playerView.GetRigidbody2D(), moveJoystick, 150f);
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
