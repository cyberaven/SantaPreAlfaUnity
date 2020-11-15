using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : Panel
{
    private void Awake()
    {
        StartButton.StartButtonClkEve += StartButtonClk;
    }

    private void StartButtonClk()
    {
        Hide();
    }
}
