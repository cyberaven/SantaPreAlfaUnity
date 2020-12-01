using System.Collections;
using UnityEngine;
using Spine.Unity;


public class PlayerView : MonoBehaviour
{
    [SerializeField] private MovingSystem MovingSystem;

    private AnimationPack AnimationPack;
    private SkeletonAnimation SkeletonAnimation;

    private void Awake()
    {
        MovingSystem = Instantiate(MovingSystem, transform);

        SkeletonAnimation = GetComponent<SkeletonAnimation>();
        if (!SkeletonAnimation)
        {
            throw new System.Exception("No SkeletonAnimation on gameObject: " + gameObject);
        }
    }

    public void SetAnimationPack(AnimationPack animationPack)
    {
        AnimationPack = animationPack;
    }

    public void PlayDamage()
    {
        SkeletonAnimation.AnimationState.SetAnimation(3, AnimationPack.Damage, false);
    }
    public void PlayIdle()
    {
        SkeletonAnimation.AnimationState.SetAnimation(1, AnimationPack.Idle, true);
    }
    public void PlayIdle1()
    {
        SkeletonAnimation.AnimationState.SetAnimation(1, AnimationPack.Idle1, true);
    }
    public void PlayShoot()
    {
        SkeletonAnimation.AnimationState.SetAnimation(2, AnimationPack.Shoot, false);
    }
    public void PlayShoot1()
    {
        SkeletonAnimation.AnimationState.SetAnimation(2, AnimationPack.Shoot1, false);
    }


    public MovingSystem GetMovingSystem()
    {
        return MovingSystem;
    }

}
