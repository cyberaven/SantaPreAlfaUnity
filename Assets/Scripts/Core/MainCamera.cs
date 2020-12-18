using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private MovingSystem MovingSystem;
  
    private Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);        
    }
   
    private void OnEnable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;             
    }
    private void OnDisable()
    {
        LevelCreator.LevelCreatedEve -= LevelCreated;       
    }
   
    private void LevelCreated(Level level)
    {
        MovingSystem.DirectionMoveOn(Rigidbody2D, Vector3.right);        
    }   
}
