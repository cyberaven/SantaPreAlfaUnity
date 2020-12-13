using System;
using UnityEngine;

public class GameStateMashine : MonoBehaviour
{
    private EStateMashine EStateMashine;

    public delegate void GameStateChangedDel(EStateMashine eStateMashine);
    public static event GameStateChangedDel GameStateChangedEve;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        SetState(EStateMashine.StarMapScene);
    }

    private void SetState(EStateMashine state)
    {
        Debug.Log("State changed: " + state, gameObject);
        GameStateChangedEve?.Invoke(state);
    }   
}