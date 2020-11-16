using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class Cloud : MonoBehaviour, IAnimationPack
{
    private SkeletonAnimation SkeletonAnimation;
    public AnimationReferenceAsset animation;

    private void Awake()
    {
        SkeletonAnimation = GetComponent<SkeletonAnimation>();

    }

    public void PlayIdle()
    {
        SkeletonAnimation.AnimationState.SetAnimation(1, animation, true);
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
