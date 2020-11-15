using UnityEngine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System;

public class SantaLamppost : MonoBehaviour
{
    private SkeletonAnimation SkeletonAnimation;
    [SerializeField] private List<AnimationReferenceAsset> Animations = new List<AnimationReferenceAsset>();
    
    private void Awake()
    {
        SkeletonAnimation = GetComponent<SkeletonAnimation>();

        Lamppost.LamppostCreatedEve += LamppostCreated;
        Lamppost.LamppostHitEve += LamppostHit;
    }

    private void LamppostHit(Lamppost lamppost)
    {
        if (gameObject == lamppost.gameObject)
        {
            int lampHealth = lamppost.GetHealth();
            SkeletonAnimation.AnimationState.SetAnimation(1, Animations[lampHealth], true);
        }
    
    }

    private void LamppostCreated(Lamppost lamppost)
    {
        if (gameObject == lamppost.gameObject)
        {
            int lampHealth = lamppost.GetHealth();
            SkeletonAnimation.AnimationState.SetAnimation(1, Animations[lampHealth], true);
        }
    }   
}
