using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{    
    [SerializeField] public LevelEnvironment LevelEnvironment;
    [SerializeField] private Transform WallRightPos;
    [SerializeField] private MovingSystem MovingSystem;

    private Rigidbody2D Rigidbody2D;

    private PlayerModel Player;

    private void OnEnable()
    {
        Starter.StartGameEve += StartGame;
    }
    private void OnDisable()
    {
        Starter.StartGameEve -= StartGame;
    }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);
    }

    private void Start()    
    {
        WallRightChangePos();                
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
        WallRightPos.position = new Vector3(wallPos.x * 100, wallPos.y, wallPos.z);
    }
    private void StartGame()
    {
        MovingSystem.DirectionMoveOn(Rigidbody2D, -Vector3.right);
    }
}
