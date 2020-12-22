using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Spine.Unity;

public class Santa : PlayerView
{
    private void OnEnable()
    {
        PlayerCreator.PlayerCreatedEve += PlayerCreated;
        ProjectileCanon.PlayerShotedEve += PlayerShoted;
        
    }
    private void OnDisable()
    {
        PlayerCreator.PlayerCreatedEve -= PlayerCreated;
        ProjectileCanon.PlayerShotedEve -= PlayerShoted;       
    }
   
    private void PlayerCreated(PlayerModel player)
    {
        PlayIdle();
        PlayIdle1();
    }  
    private void PlayerShoted(GameObject go)
    {
        if (go == gameObject)
        {
            PlayShoot();
        }
    }
}
