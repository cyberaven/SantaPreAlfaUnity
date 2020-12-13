using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    [SerializeField] private int LevelId = 0;
    [SerializeField] private ELvlAssetName LvlAssetName = ELvlAssetName.NONE;
    [SerializeField] private EPlrViewAssetName PlrViewAssetName = EPlrViewAssetName.NONE;
    [Space]
    [SerializeField] private GameUI GameUI;
    [SerializeField] private LevelCreator LevelCreator;
    [SerializeField] private PlayerCreator PlayerCreator;

    public delegate void StartGameDel();
    public static event StartGameDel StartGameEve;


    private void Awake()
    {
        GameUI = Instantiate(GameUI);
        LevelCreator = Instantiate(LevelCreator);
        PlayerCreator = Instantiate(PlayerCreator);        
    }
    private void OnEnable()
    {
        StartButton.StartButtonClkEve += StartButtonClk;
    }
    private void OnDisable()
    {
        StartButton.StartButtonClkEve -= StartButtonClk;
    }

    private void StartButtonClk()
    {
        PlayerModel player = PlayerCreator.CreatePlayer(PlrViewAssetName);
        Level l = LevelCreator.CreateLevel(0, LvlAssetName);         
        StartGameEve?.Invoke();
    }
}


namespace Rules
{
    //public class Rule1 : MonoBehaviour
    //{
    //    //так делать нельзя!!!
    //    private int printerError = 0;

    //    private void Start()
    //    {
    //        if (printerError == 0)//для этого есть true/false. Вот так надо --> if(true)DoWork(); 
    //        {
    //            DoWork();
    //        }
    //    }

    //    private void DoWork()
    //    {            
    //    }

    //    private void Examples()
    //    {
    //        //obj?.method?.attr

    //        //SomeClass a = null;
    //        //a?.some_method();
    //        //if (a != null)
    //        //{
    //        //    a.some_method();
    //        //}
    //    }
    //}
}