using UnityEngine;
using System.Collections;
using System;


public class PlayerCreator : MonoBehaviour
{
    [SerializeField] private Player Player;

    private void Awake()
    {
        Level.LevelCreatedEve += LevelCreated;
    }

    private void LevelCreated(Level level)
    {
        Player p = CreatePlayer();        
    }

    private Player CreatePlayer()
    {
        return Instantiate(Player);
    }
}
