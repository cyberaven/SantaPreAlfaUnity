using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private List<Level> Levels = new List<Level>();
    int FrstLevel = 0;


    public void CreateFrstLevel()
    {
        CreateLevel(FrstLevel);
    }
    public void CreateLevel(int levelId)
    {
        Level l = Instantiate(Levels[levelId], transform);
    }
}
