using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Spine.Unity;

public class Santa : MonoBehaviour, IAnimationPack
{
    private SkeletonAnimation SkeletonAnimation;
    public AnimationReferenceAsset ELF_HIT;
    public AnimationReferenceAsset ELF_HIT2;
    public AnimationReferenceAsset ELF_IDLE;
    public AnimationReferenceAsset SANI_DAMAGE;
    public AnimationReferenceAsset SANI_FLY;
    public AnimationReferenceAsset SANTA_DROP;
    public AnimationReferenceAsset SANTA_IDLE;

    private void Awake()
    {
        Player.PlayerShotedEve += PlayerShoted;
        Player.PlayerCreatedEve += PlayerCreated;

        SkeletonAnimation = GetComponent<SkeletonAnimation>();  
        
    }

    private void PlayerCreated(Player player)
    {
        PlayIdle();
    }  
    private void PlayerShoted(Player player, Vector3 direction)
    {
        PlayShoot();                
    }

    public void PlayIdle()
    {
        SkeletonAnimation.AnimationState.SetAnimation(1, ELF_IDLE, true);
        SkeletonAnimation.AnimationState.SetAnimation(2, SANTA_IDLE, true);
    }
    public void PlayShoot()
    {
        SkeletonAnimation.AnimationState.SetAnimation(3, ELF_HIT, false);
    }
    public void PlayDamage()
    {
        throw new NotImplementedException();
    }
}
