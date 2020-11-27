using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelEnvironment : MonoBehaviour
{
    public LevelBG LevelBG;
    [Space]
    public List<Cloud> Clouds = new List<Cloud>();
    public Transform CloudFolder;
    [Space]
    public List<BGHouse> BGHouse = new List<BGHouse>();    
    public Transform BGHouseFolder;
    [Space]
    public List<SkyBack> SkyBacks = new List<SkyBack>();    
    public Transform SkyBackFolder;
    [Space]
    public List<House> Houses = new List<House>();
    public Transform HouseFolder;
    [Space]
    public List<Lamppost> Lampposts = new List<Lamppost>();
    public Transform LamppostFolder;
    [Space]
    public List<Virus> Viruses = new List<Virus>();
    public Transform VirusFolder;
}
