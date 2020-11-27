using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class PlayerCreator : MonoBehaviour
{
    [SerializeField] private List<PlayerViewAsset> PlayerViewAssets = new List<PlayerViewAsset>();
    [Space]
    [SerializeField] private PlayerModel PlayerPrefab;
    private PlayerModel CurrentPlayer;

    public delegate void PlayerCreatedDel(PlayerModel player);
    public static event PlayerCreatedDel PlayerCreatedEve;
   
    private void OnCurrentPlayer()
    {
        CurrentPlayer.gameObject.SetActive(true);
    }
    private void OffCurrentPlayer()
    {
        CurrentPlayer.gameObject.SetActive(false);
    }

    public PlayerModel CreatePlayer(EPlrViewAssetName name)
    {
        PlayerViewAsset playerViewAsset = GetPlayerViewAsset(name);

        CurrentPlayer = Instantiate(PlayerPrefab, transform);
        CurrentPlayer.SetViewAsset(playerViewAsset);
       
        PlayerCreatedEve?.Invoke(CurrentPlayer);
        return CurrentPlayer;
    }

    private PlayerViewAsset GetPlayerViewAsset(EPlrViewAssetName name)
    {
        foreach (PlayerViewAsset playerViewAsset in PlayerViewAssets)
        {
            if(playerViewAsset.GetEPlrAssetName() == name)
            {
                return playerViewAsset;
            }
        }

        throw new Exception("No PlayerViewAsset with name: " + name);
    }
}
