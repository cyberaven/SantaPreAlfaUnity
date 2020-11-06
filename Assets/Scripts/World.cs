using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private PlanetPrefab PlanetPrefab;

    private List<PlanetPrefab> Planets = new List<PlanetPrefab>();

    private int StartPlanetsCount = 10000;
    private Vector2 WorldCenter = Vector2.zero;
    private int WorldSize = 1000000;


    private void Start()
    {
        Planets = CreatePlanets(StartPlanetsCount);
    }

    //фабрика планет
    private List<PlanetPrefab> CreatePlanets(int count)
    {
        List<PlanetPrefab> result = new List<PlanetPrefab>();

        for (int i = 0; i < count; i++)
        {
            PlanetPrefab p = Instantiate(PlanetPrefab, transform);

            p.transform.position = CyberavenUtilites.RandomPosition(WorldCenter, WorldSize);
            p.transform.localScale = CyberavenUtilites.RandomSize(p.GetMaxSize());

            result.Add(p);
        }

        return result;
    }

    
}
