using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class AnimationPack : MonoBehaviour, IAnimationPack
{
    [SerializeField] private AnimationReferenceAsset Damage;
    [SerializeField] private AnimationReferenceAsset Idle;
    [SerializeField] private AnimationReferenceAsset Idle1;
    [SerializeField] private AnimationReferenceAsset Shoot;
    [SerializeField] private AnimationReferenceAsset Shoot1;

    private SkeletonAnimation SkeletonAnimation;

    private void Awake()
    {
        SkeletonAnimation = GetComponent<SkeletonAnimation>();
        Debug.Log("333: " + SkeletonAnimation);
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
        Debug.Log("111 " + SkeletonAnimation);
        Debug.Log("222 " + Idle);

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
