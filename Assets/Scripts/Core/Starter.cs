using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{    
    [SerializeField] private GameUI GameUI;
    [SerializeField] private LevelCreator LevelCreator;
    [SerializeField] private PlayerCreator PlayerCreator;
    [SerializeField] private StarsCreator StarsCreator;

    public delegate void StartGameDel();
    public static event StartGameDel StartGameEve;


    private void Awake()
    {
        GameUI = Instantiate(GameUI);
        LevelCreator = Instantiate(LevelCreator);
        PlayerCreator = Instantiate(PlayerCreator);
        StarsCreator = Instantiate(StarsCreator);
    }
    private void OnEnable()
    {
        StartLevelButton.StartLevelButtonClkEve += StartLevelButtonClk;
    }
    private void OnDisable()
    {
        StartLevelButton.StartLevelButtonClkEve -= StartLevelButtonClk;
    }

    private void StartLevelButtonClk(int levelId, EPlrViewAssetName ePlrViewAssetName, ELvlAssetName eLvlAssetName)
    {
        PlayerModel player = PlayerCreator.CreatePlayer(ePlrViewAssetName);
        Level l = LevelCreator.CreateLevel(levelId, eLvlAssetName);
        StartGameEve?.Invoke();
    }
}