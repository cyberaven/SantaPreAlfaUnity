﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Level Move")]
    [SerializeField] private MovingSystem MovingSystem;
    [SerializeField] private float StartMovingSpeed = 5f;
    [SerializeField] private float MaxMovingSpeed = 10f;
    [SerializeField] private float MinMovingSpeed = 1f;
    [Space]
    [SerializeField] public float PointWinValue = 0;
    [SerializeField] public LevelEnvironment LevelEnvironment;
    [SerializeField] private Transform WallRightPos;    
    private Rigidbody2D Rigidbody2D;

    
    private LevelViewAsset levelViewAsset;
    public LevelViewAsset LevelViewAsset { get => levelViewAsset; set => levelViewAsset = value; }
    
    
    [SerializeField] private List<LevelLocation> levelLocations = new List<LevelLocation>();
    public List<LevelLocation> LevelLocations { get => levelLocations;}

  
    [SerializeField] private LevelBuilder LevelBuilder;


    private void OnEnable()
    {
        Starter.StartGameEve += StartGame;
        PlayerLogick.PlayerViewChangeXPosEve += PlayerViewChangeXPosEve;
    }
    private void OnDisable()
    {
        Starter.StartGameEve -= StartGame;
        PlayerLogick.PlayerViewChangeXPosEve -= PlayerViewChangeXPosEve;
    }

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);
        LevelBuilder = Instantiate(LevelBuilder, transform);
    }
     
    private void PlayerViewChangeXPosEve(float delta)
    {        
        MovingSystem.DirectionMoveOn(Rigidbody2D, -Vector3.right, StartMovingSpeed + delta * 100f, MaxMovingSpeed, MinMovingSpeed);        
    }   
    private void StartGame()
    {
        MovingSystem.DirectionMoveOn(Rigidbody2D, -Vector3.right, StartMovingSpeed, MaxMovingSpeed, MinMovingSpeed);
    }
    public void BuildStartLevel()
    {
        LevelBuilder.Run(this);
    }  
}
