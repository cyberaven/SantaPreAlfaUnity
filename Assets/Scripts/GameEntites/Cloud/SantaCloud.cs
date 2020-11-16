using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SantaCloud : MonoBehaviour, IAnimationPack
{
    private SkeletonAnimation SkeletonAnimation;
    public AnimationReferenceAsset Animation;

    private void Awake()
    {
        Cloud.CloudCreatedEve += CloudCreated;
        SkeletonAnimation = GetComponent<SkeletonAnimation>();

    }

    private void CloudCreated(Cloud cloud)
    {
        if(gameObject == cloud.gameObject)
        {
            PlayIdle();
        }
    }

    public void PlayIdle()
    {
        SkeletonAnimation.AnimationState.SetAnimation(1, Animation, true);
    }
    public void PlayShoot()
    {
        throw new NotImplementedException();

    }
    public void PlayDamage()
    {
        throw new NotImplementedException();
    }
}
