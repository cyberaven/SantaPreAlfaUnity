using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private PlayerView PlayerView;
    [SerializeField] private PlayerLogick PlayerLogick;

    private void Awake()
    {
        PlayerLogick.SetPlayerModel(this);
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

}
