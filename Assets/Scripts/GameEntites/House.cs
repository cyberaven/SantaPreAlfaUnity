using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Transform StarsCreatePoint;
    private bool StarsCreated = false;

    private SkeletonAnimation SkeletonAnimation;
    [SerializeField] private List<AnimationReferenceAsset> Animations = new List<AnimationReferenceAsset>();
    private int CurrentAnimation = 0;

    public delegate void HouseCreateStarsDel(int count, Vector3 position);
    public static event HouseCreateStarsDel HouseCreateStarsEve;


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
        if (collision.tag == "Bomb")
        {
            CreateStars();
        }
    }

    private void CreateStars()
    {
        if (!StarsCreated)
        {
            if (CurrentAnimation == Animations.Count)
            {
                HouseCreateStarsEve?.Invoke(5, StarsCreatePoint.position);
                StarsCreated = true;
            }
        }
    }

    private void SetNextAnimation()
    {        
        if (CurrentAnimation <= Animations.Count - 1)
        {
            SkeletonAnimation.AnimationState.SetAnimation(1, Animations[CurrentAnimation], true);
            CurrentAnimation++;
        }
    }
}
