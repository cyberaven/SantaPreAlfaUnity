using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class AnimationPack : MonoBehaviour, IAnimationPack
{
    [SerializeField] public AnimationReferenceAsset Damage;
    [SerializeField] public AnimationReferenceAsset Idle;
    [SerializeField] public AnimationReferenceAsset Idle1;
    [SerializeField] public AnimationReferenceAsset Shoot;
    [SerializeField] public AnimationReferenceAsset Shoot1;

    private SkeletonAnimation SkeletonAnimation;

    private void Awake()
    {
        SkeletonAnimation = GetComponent<SkeletonAnimation>();        
        if(!SkeletonAnimation)
        {
            throw new System.Exception("No SkeletonAnimation on gameObject: " + gameObject);
        }
    }

    public void PlayDamage()
    {
        SkeletonAnimation.AnimationState.SetAnimation(3, Damage, false);
    }

    public void PlayIdle()
    {
        SkeletonAnimation.AnimationState.SetAnimation(1, Idle, true);
    }
    public void PlayIdle1()
    {
        SkeletonAnimation.AnimationState.SetAnimation(1, Idle1, true);
    }

    public void PlayShoot()
    {        
        SkeletonAnimation.AnimationState.SetAnimation(2, Shoot, false);
    }
    public void PlayShoot1()
    {   
        SkeletonAnimation.AnimationState.SetAnimation(2, Shoot1, false);
    }
    
}
