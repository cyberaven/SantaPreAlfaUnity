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
        HealthSystem.HealthChangeEve += HealthChange;       
    }

    private void HealthChange(IHaveHealth haveHealth)
    {
        if(gameObject == haveHealth.GetGameObject())
        {
            int lampHealth = haveHealth.GetCurrentHealth();
            if (lampHealth >= 0)
            {
                SkeletonAnimation.AnimationState.SetAnimation(1, Animations[lampHealth], true);
            }
        }
    }
    private void LamppostCreated(Lamppost lamppost)
    {
        if (gameObject == lamppost.gameObject)
        {
            int lampHealth = lamppost.GetCurrentHealth();
            SkeletonAnimation.AnimationState.SetAnimation(1, Animations[lampHealth], true);
        }
    }   
}
