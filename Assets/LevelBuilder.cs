using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    private Level Level;
    private bool buildEnable = false;

    private void OnEnable()
    {
        Starter.StartGameEve += StartGame;
        LevelWallRight.LevelWallRightTouchLocationEndTrigerEve += LevelWallRightTouchLocationEndTriger;
    }
    private void OnDisable()
    {
        Starter.StartGameEve -= StartGame;
        LevelWallRight.LevelWallRightTouchLocationEndTrigerEve -= LevelWallRightTouchLocationEndTriger;
    }   

    private void StartGame()
    {
        buildEnable = true;
    }
    public void Run(Level level)
    {
        Level = level;
        BuildLocation(0);
    }    
    private void BuildLocation(int id)
    {
        LevelLocation levelLocation = Level.LevelLocations[id];
        Instantiate(levelLocation, Level.transform);
    }
    private void LevelWallRightTouchLocationEndTriger()
    {
        BuildNextLocation();
    }
    private void BuildNextLocation()
    {
        BuildLocation(0);
    }
}
