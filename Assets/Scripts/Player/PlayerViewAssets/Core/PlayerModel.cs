using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private PlrView PlrView;
    [SerializeField] private PlrLogick PlrLogick;

    public void SetViewAsset(PlayerViewAsset playerViewAsset)
    {
        PlrView.SetAnimationPack(playerViewAsset.GetAnimationPack());
    }
    public void SetControllers(VariableJoystick MoveJoystick, VariableJoystick ShootJoystick)
    {
        PlrLogick.SetControllers(MoveJoystick, ShootJoystick);
    }

}
