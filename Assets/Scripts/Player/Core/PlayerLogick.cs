using System;
using System.Collections;
using UnityEngine;


public class PlayerLogick : MonoBehaviour
{
    private PlayerModel PlayerModel;

    private VariableJoystick MoveJoystick;
    
    private VariableJoystick ShootJoystick;
    [SerializeField] private ShootSystem ShootSystem;
    [SerializeField] private float ShootJoystickActionLimiter = 0.5f;

    public delegate void PlayerViewChangeXPosDel(float x);
    public static event PlayerViewChangeXPosDel PlayerViewChangeXPosEve;

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
        CheckShootJoystick();
        CheckViewPosition();
    }
    #endregion

    private void CheckViewPosition()
    {
        PlayerView playerView = PlayerModel.GetPlayerView();
        Transform viewStartPosition = PlayerModel.GetViewStartPosition();
        float value = 0;

        if (playerView.transform.localPosition.x > viewStartPosition.localPosition.x)
        {
            value = playerView.transform.localPosition.x - viewStartPosition.localPosition.x;
        }
        if (playerView.transform.localPosition.x < viewStartPosition.localPosition.x)
        {
            value = viewStartPosition.localPosition.x - playerView.transform.localPosition.x;
        }

        if (value != 0)
        {
            PlayerViewChangeXPosEve?.Invoke(value);
        }
    }
    private void CheckShootJoystick()
    {
        if (ShootJoystick.Vertical > ShootJoystickActionLimiter || ShootJoystick.Vertical < -ShootJoystickActionLimiter || ShootJoystick.Horizontal > ShootJoystickActionLimiter || ShootJoystick.Horizontal < -ShootJoystickActionLimiter)
        {
            Vector3 direction = Vector3.up * ShootJoystick.Vertical + Vector3.right * ShootJoystick.Horizontal;
            ShootSystem.Fire(EProjectileType.Bullet, PlayerModel.gameObject, direction, PlayerModel.GetPlayerView().transform.position);           
        }
    }
    private void DropBombButtonClk()
    {
        ShootSystem.Fire(EProjectileType.Bomb, PlayerModel.gameObject, - PlayerModel.transform.up, PlayerModel.GetPlayerView().transform.position);
    }
    
    public void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick)
    {
        MoveJoystick = moveJoystick;
        MoveSetupPlayerView(PlayerModel.GetPlayerView(), MoveJoystick);        
     
        ShootJoystick = shootJoystick;        
    }

    private void MoveSetupPlayerView(PlayerView playerView, VariableJoystick moveJoystick)
    {         
       playerView.GetMovingSystem().ControllMoveOn(playerView.GetRigidbody2D(), moveJoystick, 20f);
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
