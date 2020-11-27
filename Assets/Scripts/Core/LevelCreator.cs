using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private List<Level> Levels = new List<Level>();   
    [SerializeField] private List<LevelViewAsset> LevelViewAssets = new List<LevelViewAsset>();
    [SerializeField] private int MaxLeghtLevel = 10;

    public delegate void LevelCreatedDel(Level level);
    public static event LevelCreatedDel LevelCreatedEve;

    public Level CreateLevel(int id, ELvlAssetName name, int maxLeghtLevel = 10)
    {
        MaxLeghtLevel = maxLeghtLevel;

        if (id == 0)
        {
            Level l = CreateLevelWithRandomEnvironment(name);           
            LevelCreatedEve?.Invoke(l);
            return l;
        }
        else
        {
            LevelViewAsset levelViewAsset = GetLevelViewAsset(name);
            Level l = Instantiate(Levels[id], transform);
            l.SetViewAsset(levelViewAsset);
            LevelCreatedEve?.Invoke(l);
            return l;
        }

        throw new Exception("LevelCreator CreateLevel Error.");
    }

    private Level CreateLevelWithRandomEnvironment(ELvlAssetName name)
    {
        LevelViewAsset levelViewAsset = GetLevelViewAsset(name);
        Level l = Instantiate(Levels[0], transform);

        l.LevelEnvironment.LevelBG = CreateBGImg(levelViewAsset.GetLevelBG(), l.transform);
        l.LevelEnvironment.Clouds = CreateCloud();
        CreateBGHouse();
        CreateSkyBack();
        CreateLampPost();
        CreateHouse();
        CreateVirus();

        
        l.SetViewAsset(levelViewAsset);
        return l;
    }

    private LevelViewAsset GetLevelViewAsset(ELvlAssetName name)
    {
        foreach (LevelViewAsset levelViewAsset in LevelViewAssets)
        {
            if(levelViewAsset.GetAssetName() == name)
            {
                return levelViewAsset;
            }
        }
        throw new Exception("No LevelViewAsset with name: " + name);
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
            bGHouse1.transform.position = new Vector3(bGHouse1.transform.position.x + i * 20f, bGHouse1.transform.position.y + randYValue - 1.3f, bGHouse1.transform.position.z);
        }

        for (int i = 0; i < MaxLeghtLevel; i++)
        {
            BGHouse bGHouse2 = Instantiate(BGHouse2, BGHouseFolder);
            float randYValue = UnityEngine.Random.Range(0, 1);
            bGHouse2.transform.position = new Vector3(bGHouse2.transform.position.x + i * 13f, bGHouse2.transform.position.y + randYValue - 1.3f, bGHouse2.transform.position.z);
        }
    }
    private List<Cloud> CreateCloud()
    {
        List<Cloud> result = new List<Cloud>();

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

        return result;

    }
    private LevelBG CreateBGImg(LevelBG levelBG, Transform parent)
    {
        LevelBG lvlBG = Instantiate(levelBG, transform);
        lvlBG.transform.localScale = new Vector3(MaxLeghtLevel, 3, 1);
        lvlBG.transform.position = new Vector3(MaxLeghtLevel * 10 - 20, lvlBG.transform.position.y, lvlBG.transform.position.z);
        return lvlBG;
    }
}
