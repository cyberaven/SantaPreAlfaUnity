using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineAnim : MonoBehaviour
{
    private SkeletonAnimation SkeletonAnimation;
    public AnimationReferenceAsset Animation;
    public AnimationReferenceAsset Animation1;
    public AnimationReferenceAsset Animation2;

    private void Awake()
    {
        SkeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    private void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            SkeletonAnimation.AnimationState.SetAnimation(1, Animation, false);
        }
        if (Input.GetKeyDown("s"))
        {
            SkeletonAnimation.AnimationState.SetAnimation(1, Animation1, false);
        }
        if (Input.GetKeyDown("d"))
        {
            SkeletonAnimation.AnimationState.SetAnimation(1, Animation2, false);
        }
    }
}
