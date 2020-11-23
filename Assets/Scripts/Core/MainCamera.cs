using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private FollowToObjSystem FollowToObjSystem;
    private Player Player;

    private void Awake()
    {
        FollowToObjSystem = GetComponent<FollowToObjSystem>();
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

    private void PlayerCreated(Player player)
    {
        Player = player;
    }
    private void LevelCreated(Level level)
    {        
        FollowToObjSystem.FollowOn(Player.transform, true, false, false);
    }
}
