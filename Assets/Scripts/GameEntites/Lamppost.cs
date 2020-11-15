using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Lamppost : MonoBehaviour
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

    //private SpriteRenderer SpriteRenderer;

    //[SerializeField] private List<Sprite> Sprites = new List<Sprite>();
    //private int CurrentSprite = 0;

    //private void Awake()
    //{
    //    SpriteRenderer = GetComponent<SpriteRenderer>();
    //    SpriteRenderer.sprite = Sprites[CurrentSprite];
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Bullet")
    //    {
    //        SetNextSprite();            
    //    }
    //}

    //private void SetNextSprite()
    //{
    //    CurrentSprite++;
    //    if (CurrentSprite <= Sprites.Count - 1)
    //    {
    //        SpriteRenderer.sprite = Sprites[CurrentSprite];
    //    }
    //}       
}
