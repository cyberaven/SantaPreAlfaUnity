using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform CloudFolder;
    [SerializeField] private Transform BGHouseFolder;
    [SerializeField] private Transform SkyBackFolder;
    [SerializeField] private Transform HouseFolder;
    [SerializeField] private Transform LamppostFolder;
    [SerializeField] private Transform VirusFolder;

    [SerializeField] private LevelBG LevelBG;
    [SerializeField] private Cloud Cloud;
    [SerializeField] private BGHouse BGHouse1;
    [SerializeField] private BGHouse BGHouse2;
    [SerializeField] private SkyBack SkyBack1;
    [SerializeField] private SkyBack SkyBack2;
    [SerializeField] private House House;
    [SerializeField] private Lamppost Lamppost;
    [SerializeField] private Virus Virus;

    private float MaxLeghtLevel = 10;

    public delegate void LevelCreatedDel(Level level);
    public static event LevelCreatedDel LevelCreatedEve;

    private void Start()    
    {
        CreateBGImg();
        CreateCloud();
        CreateBGHouse();
        CreateSkyBack();
        CreateLampPost();
        CreateHouse();
        CreateVirus();

        LevelCreatedEve?.Invoke(this);
    }

    private void CreateVirus()
    {
        for (int i = 0; i < MaxLeghtLevel * 10; i++)
        {
            Virus virus = Instantiate(Virus, VirusFolder);
            virus.transform.position = new Vector3(i * 20f, virus.transform.position.y, virus.transform.position.z);
        }
    }

    private void CreateLampPost()
    {
        for (int i = 0; i < MaxLeghtLevel; i++)
        {
            Lamppost lamp = Instantiate(Lamppost, LamppostFolder);
            lamp.transform.position = new Vector3(lamp.transform.position.x + i * 18.3f, lamp.transform.position.y - 0.5f, lamp.transform.position.z);
        }
    }

    private void CreateHouse()
    {
        for (int i = 0; i < MaxLeghtLevel * 10; i++)
        {
            House house = Instantiate(House, HouseFolder);
            house.transform.position = new Vector3(house.transform.position.x + i * 9f, house.transform.position.y - 3.5f, house.transform.position.z);
            house.transform.localScale = new Vector3(house.transform.localScale.x * 1.6f, house.transform.localScale.y * 1.6f, 0);

        }
    }

    private void CreateSkyBack()
    {
        for (int i = 0; i < MaxLeghtLevel; i++)
        {
            SkyBack skyBack1 = Instantiate(SkyBack1, SkyBackFolder);
            skyBack1.transform.position = new Vector3(skyBack1.transform.position.x + i * 20f, skyBack1.transform.position.y, skyBack1.transform.position.z);
        }
        for (int i = 0; i < MaxLeghtLevel; i++)
        {
            SkyBack skyBack2 = Instantiate(SkyBack2, SkyBackFolder);
            skyBack2.transform.position = new Vector3(skyBack2.transform.position.x + i * 20f, skyBack2.transform.position.y, skyBack2.transform.position.z);
        }
    }

    private void CreateBGHouse()
    {
        for (int i = 0; i < MaxLeghtLevel; i++)
        {
            BGHouse bGHouse1 = Instantiate(BGHouse1, BGHouseFolder);
            float randYValue = UnityEngine.Random.Range(0, 1);
            bGHouse1.transform.position = new Vector3(bGHouse1.transform.position.x + i * 20f, bGHouse1.transform.position.y + randYValue - 0.8f, bGHouse1.transform.position.z);
        }

        for (int i = 0; i < MaxLeghtLevel; i++)
        {
            BGHouse bGHouse2 = Instantiate(BGHouse2, BGHouseFolder);
            float randYValue = UnityEngine.Random.Range(0, 1);
            bGHouse2.transform.position = new Vector3(bGHouse2.transform.position.x + i * 13f, bGHouse2.transform.position.y + randYValue - 0.8f, bGHouse2.transform.position.z);
        }
    }

    private void CreateCloud()
    {
        for (int i = 0; i < MaxLeghtLevel * 2; i++)
        {
            Cloud c = Instantiate(Cloud, CloudFolder);
            int randYValue = UnityEngine.Random.Range(5, 7);
            int randXIndent = UnityEngine.Random.Range(1, 200);
            c.transform.position = new Vector3(c.transform.position.x + i + randXIndent, randYValue, 0);
        }
        for (int j = 0; j < MaxLeghtLevel * 2; j++)
        {
            Cloud d = Instantiate(Cloud, CloudFolder);
            int randYValueJ = UnityEngine.Random.Range(6, 10);
            int randXIndentJ = UnityEngine.Random.Range(1, 200);
            d.transform.position = new Vector3(d.transform.position.x + j + randXIndentJ, randYValueJ, 0);
            d.transform.localScale = new Vector3(d.transform.localScale.x * 2, d.transform.localScale.y * 2, 0);
        }
    }

    private void CreateBGImg()
    {
        LevelBG levelBG = Instantiate(LevelBG, transform);
        levelBG.transform.localScale = new Vector3(MaxLeghtLevel, 3, 1);
        levelBG.transform.position = new Vector3(MaxLeghtLevel * 10 - 20, levelBG.transform.position.y, levelBG.transform.position.z);
    }
}
