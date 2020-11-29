using System.Collections;
using UnityEngine;

public class LevelViewAsset : MonoBehaviour
{
    [SerializeField] private ELvlAssetName AssetName = ELvlAssetName.NONE;
    public ELvlAssetName GetAssetName()
    {
        return AssetName;
    }

    [SerializeField] private LevelBG LevelBG;
    public LevelBG GetLevelBG()
    {
        return LevelBG;
    }

    [SerializeField] private Cloud Cloud;
    public Cloud GetCloud()
    {
        return Cloud;
    }

    [SerializeField] private BGHouse BGHouse1;
    public BGHouse GetBGHouse1()
    {
        return BGHouse1;
    }

    [SerializeField] private BGHouse BGHouse2;
    public BGHouse GetBGHouse2()
    {
        return BGHouse2;
    }

    [SerializeField] private SkyBack SkyBack1;
    public SkyBack GetSkyBack1()
    {
        return SkyBack1;
    }

    [SerializeField] private SkyBack SkyBack2;
    public SkyBack GetSkyBack2()
    {
        return SkyBack2;
    }

    [SerializeField] private House House;
    public House GetHouse()
    {
        return House;
    }

    [SerializeField] private Lamppost Lamppost;
    public Lamppost GetLamppost()
    {
        return Lamppost;
    }

    [SerializeField] private Virus Virus;
    public Virus GetVirus()
    {
        return Virus;
    }

    
}
