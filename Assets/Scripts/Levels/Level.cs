using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{    
    [SerializeField] public LevelEnvironment LevelEnvironment;

    [SerializeField] private Transform WallRightPos;

    [SerializeField] private Transform PlayerStartPosition;   

    private PlayerModel Player;    

    private void Start()    
    {
        WallRightChangePos();                
    }
    
    public void SetPlayerOnStartPosition(PlayerModel player)
    {       
        player.transform.position = PlayerStartPosition.position;
    }
    public PlayerModel GetPlayer()
    {
        return Player;
    }
    public void SetPlayer(PlayerModel player)
    {
        Player = player;
    }
    private void WallRightChangePos()
    {
        Vector3 wallPos = WallRightPos.position;
        WallRightPos.position = new Vector3(wallPos.x * 10, wallPos.y, wallPos.z);
    }
}
