using System;
using System.Collections;
using UnityEngine;


public class StarsCreator : MonoBehaviour
{
    [SerializeField] private ParticleSystem StarsCloud;    

    private void OnEnable()
    {
        House.HouseCreateStarsEve += HouseCreateStars;
    }
    private void OnDisable()
    {
        House.HouseCreateStarsEve += HouseCreateStars;
    }

    private void Update()
    {
        
    }

    private void HouseCreateStars(int count, Vector3 position)
    {
        ParticleSystem sc = Instantiate(StarsCloud);                
        var emission = sc.emission;
        emission.rateOverTime = count;
        sc.transform.position = position;
    }
}

public class MoveStarsCont
{

}