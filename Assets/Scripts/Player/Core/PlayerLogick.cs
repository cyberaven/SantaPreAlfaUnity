using System.Collections;
using UnityEngine;


public class PlayerLogick : MonoBehaviour
{
    private PlayerModel PlayerModel;

    private VariableJoystick MoveJoystick;
    private VariableJoystick ShootJoystick;

    [SerializeField] private ShootSystem ShootSystem;
    [SerializeField] private MovingSystem MovingSystem;

    private void Awake()
    {        
        MovingSystem = Instantiate(MovingSystem, transform);
        ShootSystem = Instantiate(ShootSystem, transform);
    }

    public void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick)
    {
        MoveJoystick = moveJoystick;
        MovingSystem.Init(PlayerModel.GetPlayerView().GetComponent<Rigidbody2D>(), MoveJoystick);

        ShootJoystick = shootJoystick;
        ShootSystem.Init(PlayerModel.gameObject, ShootJoystick);
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
