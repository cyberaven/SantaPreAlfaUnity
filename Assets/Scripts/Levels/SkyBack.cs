using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SkyBack : MonoBehaviour
{
    private SkeletonAnimation SkeletonAnimation;
    [SerializeField] private List<AnimationReferenceAsset> Animations = new List<AnimationReferenceAsset>();
    private int CurrentAnimation = 0;

    private void Awake()
    {
        SkeletonAnimation = GetComponent<SkeletonAnimation>();

    }
    private void Start()
    {
        SkeletonAnimation.AnimationState.SetAnimation(1, Animations[CurrentAnimation], true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            SetNextAnimation();
        }
    }

    private void SetNextAnimation()
    {
        CurrentAnimation++;
        if (CurrentAnimation <= Animations.Count - 1)
        {
            SkeletonAnimation.AnimationState.SetAnimation(1, Animations[CurrentAnimation], true);
        }
    }
}
