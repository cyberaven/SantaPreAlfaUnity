using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Spine.Unity;

public class Santa : AnimationPack
{

    private void OnEnable()
    {
        PlayerCreator.PlayerCreatedEve += PlayerCreated;
        ShootSystem.PlayerShotedEve += PlayerShoted;
    }
    private void OnDisable()
    {
        PlayerCreator.PlayerCreatedEve -= PlayerCreated;
        ShootSystem.PlayerShotedEve -= PlayerShoted;
    }
   
    private void PlayerCreated(Player player)
    {
        PlayIdle();
        PlayIdle1();
    }  
    private void PlayerShoted(IPlayer player)
    {
        if (player.GetGameObject() == gameObject)
        {
            PlayShoot();
        }
    }
}
