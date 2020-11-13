﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private GameUI GameUI;
    [SerializeField] private LevelCreator LevelCreator;
    [SerializeField] private PlayerCreator PlayerCreator;

    private void Awake()
    {
        GameUI = Instantiate(GameUI);
        LevelCreator = Instantiate(LevelCreator);
        PlayerCreator = Instantiate(PlayerCreator);

        StartButton.StartButtonClkEve += StartButtonClk;
    }

    private void StartButtonClk()
    {
        LevelCreator.CreateFrstLevel();     
    }
}
