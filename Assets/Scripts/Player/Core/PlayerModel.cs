using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private PlayerView PlayerView;
    [SerializeField] private PlayerLogick PlayerLogick;    
    [SerializeField] private MovingSystem MovingSystem;

    private Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);

        PlayerLogick.SetPlayerModel(this);
    }
    private void OnEnable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
    }
    private void OnDisable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
    }

    public void SetViewAsset(PlayerViewAsset playerViewAsset)
    {
        PlayerView.SetAnimationPack(playerViewAsset.GetAnimationPack());
    }
    public void SetControllers(VariableJoystick MoveJoystick, VariableJoystick ShootJoystick)
    {
        PlayerLogick.SetControllers(MoveJoystick, ShootJoystick);
    }
    public PlayerView GetPlayerView()
    {
        return PlayerView;
    }
    public PlayerLogick GetPlayerLogick()
    {
        return PlayerLogick;
    }

    private void LevelCreated(Level level)
    {
        MovingSystem.Init(Rigidbody2D, transform.right);
        PlayerView.GetComponent<MovingSystem>().Init(PlayerView.GetComponent<Rigidbody2D>(), PlayerView.transform.right);
    }
}
