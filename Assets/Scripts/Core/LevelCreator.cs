using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private List<Level> Levels = new List<Level>();   
    [Space]
    [SerializeField] private List<LevelViewAsset> LevelViewAssets = new List<LevelViewAsset>();    

    public delegate void LevelCreatedDel(Level level);
    public static event LevelCreatedDel LevelCreatedEve;

    public Level CreateLevel(int id, ELvlAssetName name)
    {
        //левел должен содержать в себе локации
        //есть локации заранее заготовленные, а есть случайные,
        //левел удаляет пройденые локации слева и создает новые справа
        //в левеле есть правила относительно того когда какая локация может загрузится
        //на выходе получаем бесконечный левел
        //если тригеры появления локации конца левела не были соблюдены.
        LevelViewAsset levelViewAsset = GetLevelViewAsset(name);
        Level l = Instantiate(Levels[id], transform);
        l.LevelViewAsset = levelViewAsset;
        l.BuildStartLevel();
        LevelCreatedEve?.Invoke(l);
        return l;        
    }
    private LevelViewAsset GetLevelViewAsset(ELvlAssetName name)
    {
        foreach (LevelViewAsset levelViewAsset in LevelViewAssets)
        {
            if (levelViewAsset.GetAssetName() == name)
            {
                return levelViewAsset;
            }
        }
        throw new Exception("No LevelViewAsset with name: " + name);
    }


    //private Level CreateLevelWithRandomEnvironment(ELvlAssetName name)
    //{
    //    LevelViewAsset levelViewAsset = GetLevelViewAsset(name);
    //    Level l = Instantiate(Levels[0], transform);

    //    l.LevelEnvironment.LevelBG = CreateBGImg(levelViewAsset.GetLevelBG(), l.transform);
    //    l.LevelEnvironment.Clouds = CreateCloud(levelViewAsset.GetCloud(), l.LevelEnvironment.CloudFolder);        
    //    l.LevelEnvironment.BGHouse.AddRange(CreateBGHouse1(levelViewAsset.GetBGHouse1(), l.LevelEnvironment.BGHouseFolder));
    //    l.LevelEnvironment.BGHouse.AddRange(CreateBGHouse2(levelViewAsset.GetBGHouse2(), l.LevelEnvironment.BGHouseFolder));
    //    l.LevelEnvironment.SkyBacks.AddRange(CreateSkyBack1(levelViewAsset.GetSkyBack1(), l.LevelEnvironment.SkyBackFolder));
    //    l.LevelEnvironment.SkyBacks.AddRange(CreateSkyBack2(levelViewAsset.GetSkyBack2(), l.LevelEnvironment.SkyBackFolder));
    //    l.LevelEnvironment.Lampposts = CreateLampPost(levelViewAsset.GetLamppost(), l.LevelEnvironment.LamppostFolder);
    //    l.LevelEnvironment.Houses = CreateHouse(levelViewAsset.GetHouse(), l.LevelEnvironment.HouseFolder);
    //    l.LevelEnvironment.Viruses = CreateVirus(levelViewAsset.GetVirus(), l.LevelEnvironment.VirusFolder);
       
    //    return l;
    //}    

    //private List<Virus> CreateVirus(Virus virus, Transform parent)
    //{
    //    List<Virus> result = new List<Virus>();

    //    for (int i = 0; i < MaxLeghtLevel * 10; i++)
    //    {
    //        Virus v = Instantiate(virus, parent);
    //        v.transform.position = new Vector3(i * 20f, v.transform.position.y + 10f, v.transform.position.z);
    //        result.Add(v);
    //    }

    //    return result;
    //}
    //private List<Lamppost> CreateLampPost(Lamppost lamppost, Transform parent)
    //{
    //    List<Lamppost> result = new List<Lamppost>();

    //    for (int i = 0; i < MaxLeghtLevel; i++)
    //    {
    //        Lamppost lamp = Instantiate(lamppost, parent);
    //        lamp.transform.position = new Vector3(lamp.transform.position.x + i * 18.3f, lamp.transform.position.y - 0.5f, lamp.transform.position.z);
    //        result.Add(lamp);
    //    }

    //    return result;
    //}
    //private List<House> CreateHouse(House house, Transform parent)
    //{
    //    List<House> result = new List<House>();

    //    for (int i = 0; i < MaxLeghtLevel * 10; i++)
    //    {
    //        House h = Instantiate(house, parent);
    //        h.transform.position = new Vector3(h.transform.position.x + i * 9f, h.transform.position.y - 3.5f, h.transform.position.z);
    //        h.transform.localScale = new Vector3(h.transform.localScale.x * 1.6f, h.transform.localScale.y * 1.6f, 0);
    //        result.Add(h);
    //    }

    //    return result;
    //}
    //private List<SkyBack> CreateSkyBack1(SkyBack skyBack, Transform parent)
    //{
    //    List<SkyBack> result = new List<SkyBack>();

    //    for (int i = 0; i < MaxLeghtLevel; i++)
    //    {
    //        SkyBack skyBack1 = Instantiate(skyBack, parent);
    //        skyBack1.transform.position = new Vector3(skyBack1.transform.position.x + i * 20f, skyBack1.transform.position.y, skyBack1.transform.position.z);
    //        result.Add(skyBack1);
    //    }        

    //    return result;
    //}
    //private List<SkyBack> CreateSkyBack2(SkyBack skyBack, Transform parent)
    //{
    //    List<SkyBack> result = new List<SkyBack>();
        
    //    for (int i = 0; i < MaxLeghtLevel; i++)
    //    {
    //        SkyBack skyBack2 = Instantiate(skyBack, parent);
    //        skyBack2.transform.position = new Vector3(skyBack2.transform.position.x + i * 20f, skyBack2.transform.position.y, skyBack2.transform.position.z);
    //        result.Add(skyBack2);
    //    }

    //    return result;
    //}
    //private List<BGHouse> CreateBGHouse1(BGHouse bGHouse, Transform parent)
    //{
    //    List<BGHouse> result = new List<BGHouse>();

    //    for (int i = 0; i < MaxLeghtLevel; i++)
    //    {
    //        BGHouse bGHouse1 = Instantiate(bGHouse, parent);
    //        float randYValue = UnityEngine.Random.Range(0, 1);
    //        bGHouse1.transform.position = new Vector3(bGHouse1.transform.position.x + i * 20f, bGHouse1.transform.position.y + randYValue - 1.3f, bGHouse1.transform.position.z);
    //        result.Add(bGHouse1);
    //    }

    //    return result;
    //}
    //private List<BGHouse> CreateBGHouse2(BGHouse bGHouse, Transform parent)
    //{
    //    List<BGHouse> result = new List<BGHouse>();

    //    for (int i = 0; i < MaxLeghtLevel; i++)
    //    {
    //        BGHouse bGHouse2 = Instantiate(bGHouse, parent);
    //        float randYValue = UnityEngine.Random.Range(0, 1);
    //        bGHouse2.transform.position = new Vector3(bGHouse2.transform.position.x + i * 13f, bGHouse2.transform.position.y + randYValue - 1.3f, bGHouse2.transform.position.z);
    //        result.Add(bGHouse2);
    //    }

    //    return result;
    //}
    //private List<Cloud> CreateCloud(Cloud cloud, Transform parent)
    //{
    //    List<Cloud> result = new List<Cloud>();

    //    for (int i = 0; i < MaxLeghtLevel * 2; i++)
    //    {
    //        Cloud c = Instantiate(cloud, parent);
    //        int randYValue = UnityEngine.Random.Range(5, 7);
    //        int randXIndent = UnityEngine.Random.Range(1, 200);
    //        c.transform.position = new Vector3(c.transform.position.x + i + randXIndent, randYValue, 0);
    //        result.Add(c);
    //    }
    //    for (int j = 0; j < MaxLeghtLevel * 2; j++)
    //    {
    //        Cloud d = Instantiate(cloud, parent);
    //        int randYValueJ = UnityEngine.Random.Range(6, 10);
    //        int randXIndentJ = UnityEngine.Random.Range(1, 200);
    //        d.transform.position = new Vector3(d.transform.position.x + j + randXIndentJ, randYValueJ, 0);
    //        d.transform.localScale = new Vector3(d.transform.localScale.x * 2, d.transform.localScale.y * 2, 0);
    //        result.Add(d);
    //    }

    //    return result;
    //}
    //private LevelBG CreateBGImg(LevelBG levelBG, Transform parent)
    //{
    //    LevelBG lvlBG = Instantiate(levelBG, transform);
    //    lvlBG.transform.localScale = new Vector3(MaxLeghtLevel, 3, 1);
    //    lvlBG.transform.position = new Vector3(MaxLeghtLevel * 10 - 20, lvlBG.transform.position.y, lvlBG.transform.position.z);
    //    return lvlBG;
    //}
}
