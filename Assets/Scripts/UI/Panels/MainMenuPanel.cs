using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : Panel
{
    private void Awake()
    {
        StartLevelButton.StartLevelButtonClkEve += StartButtonClk;
    }

    private void StartButtonClk(int levelId, EPlrViewAssetName ePlrViewAssetName, ELvlAssetName eLvlAssetName)
    {
        Hide();
    }
}
