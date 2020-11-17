using UnityEngine;
using System.Collections;
using System;


public class PlayerCreator : MonoBehaviour
{
    [SerializeField] private Player PlayerPrefab;
    private Player CurrentPlayer;

    public delegate void PlayerCreatedDel(Player player);
    public static event PlayerCreatedDel PlayerCreatedEve;

    private void OnEnable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
    }
    private void OnDisable()
    {
        LevelCreator.LevelCreatedEve -= LevelCreated;
    }
    private void Start()
    {
        CreatePlayer();
        OffPlayer();
    }

    

    private void LevelCreated(Level level)
    {
        level.SetPlayer(CurrentPlayer);
        level.SetPlayerOnStartPosition();
        OnPlayer();
    }

    private void OnPlayer()
    {
        CurrentPlayer.gameObject.SetActive(true);
    }
    private void OffPlayer()
    {
        CurrentPlayer.gameObject.SetActive(false);
    }

    private void CreatePlayer()
    {
        CurrentPlayer = Instantiate(PlayerPrefab, transform);
        PlayerCreatedEve?.Invoke(CurrentPlayer);
    }
}
