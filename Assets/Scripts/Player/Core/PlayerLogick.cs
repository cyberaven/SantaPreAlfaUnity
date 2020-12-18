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
        LevelCreator.LevelCreatedEve += LevelCreated;
    }
    private void OnDisable()
    {
        DropBombButton.DropBombButtonClkEve -= DropBombButtonClk;
        LevelCreator.LevelCreatedEve -= LevelCreated;
    }    

    private void Awake()
    {   
        ShootSystem = Instantiate(ShootSystem, transform);
    }
    private void Update()
    {        
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
    
    public void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick)
    {
        MoveJoystick = moveJoystick;
        MoveSetupPlayerView(PlayerModel.GetPlayerView(), MoveJoystick);        
     
        ShootJoystick = shootJoystick;
        ShootSystem.Init(PlayerModel.gameObject, ShootJoystick);
    }

    private void MoveSetupPlayerView(PlayerView playerView, VariableJoystick moveJoystick)
    {         
       playerView.GetMovingSystem().ControllMoveOn(playerView.GetRigidbody2D(), moveJoystick, 20f);
    }
    private void LevelCreated(Level level)
    {
        PlayerView playerView = PlayerModel.GetPlayerView();
        playerView.GetMovingSystem().DirectionMoveOn(playerView.GetRigidbody2D(), Vector3.right, 20f, 19.9f);
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
