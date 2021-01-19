using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{  
    [Header("Компоненты Модели")]    
    [SerializeField] private PlayerView PlayerView;
    [SerializeField] private Transform PlayerViewStartPosition;
    [SerializeField] private Transform PlayerViewStartThrotlePosition;
    [SerializeField] private PlayerLogick PlayerLogick;
  

    private void Awake()
    {        
        PlayerLogick.SetPlayerModel(this);
        SetViewOnStartPosition();
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
    public Transform GetViewStartPosition()
    {
        return PlayerViewStartPosition;
    }
    public Transform GetViewStartThrotlePosition()
    {
        return PlayerViewStartThrotlePosition;
    }


    private void SetViewOnStartPosition()
    {
        PlayerView.transform.localPosition = PlayerViewStartPosition.position;
    }
}
