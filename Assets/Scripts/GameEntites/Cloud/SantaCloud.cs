using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SantaCloud : AnimationPack
{   
    private void Awake()
    {
        Cloud.CloudCreatedEve += CloudCreated;
    }

    private void CloudCreated(Cloud cloud)
    {
        if(gameObject == cloud.gameObject)
        {
            PlayIdle();
        }
    }   
}
