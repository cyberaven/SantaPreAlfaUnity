using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private FollowToObjSystem FollowToObjSystem;
    private PlayerModel Player;
    private bool CheckPlrPosEnable = false;

    private void Awake()
    {
        FollowToObjSystem = GetComponent<FollowToObjSystem>();
    }
    private void Update()
    {
        CheckPlrPos();
    }
    private void OnEnable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
        PlayerCreator.PlayerCreatedEve += PlayerCreated;        
    }
    private void OnDisable()
    {
        LevelCreator.LevelCreatedEve -= LevelCreated;
        PlayerCreator.PlayerCreatedEve -= PlayerCreated;
    }

    private void PlayerCreated(PlayerModel player)
    {
        Player = player;
    }
    private void LevelCreated(Level level)
    {        
        FollowToObjSystem.FollowOn(Player.transform, true, false, false);
    }

    private void StartLevelTriggerVisible()
    {
        FollowToObjSystem.FollowOff();
        CheckPlrPosEnable = true;        
    }
    private void CheckPlrPos()
    {
        if (CheckPlrPosEnable == true)
        {
            if (Player.transform.position.x > 2)
            {
                FollowToObjSystem.FollowOn(Player.transform, true, false, false);
                CheckPlrPosEnable = false;
            }
        }
    }
}
