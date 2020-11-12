using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using Spine.Unity;

public class Santa : MonoBehaviour
{
    private SkeletonAnimation SkeletonAnimation;
    public AnimationReferenceAsset ELF_HIT;
    public AnimationReferenceAsset ELF_HIT2;
    public AnimationReferenceAsset ELF_IDLE;
    public AnimationReferenceAsset SANI_DAMAGE;
    public AnimationReferenceAsset SANI_FLY;
    public AnimationReferenceAsset SANTA_DROP;
    public AnimationReferenceAsset SANTA_IDLE;


    [SerializeField] private VariableJoystick MoveJoystick;
    [SerializeField] private VariableJoystick ShootJoystick;

    [SerializeField] private Bullet Bullet;
    private float ShootCooldown = 1;
    private float ShootTime = 0;

    private float MoveSpeed = 100f;

    private Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        SkeletonAnimation = GetComponent<SkeletonAnimation>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable()
    {
        Camera.main.transform.SetParent(transform);
        SkeletonAnimation.AnimationState.SetAnimation(1, ELF_IDLE, true);
        SkeletonAnimation.AnimationState.SetAnimation(2, SANTA_IDLE, true);
    }
    
    private void FixedUpdate()
    {
        Move();
        Shoot();
        ShootTimer();
    }

    private void ShootTimer()
    {
       if(ShootTime > 0)
       {
            ShootTime -= Time.deltaTime;
       }
    }

    private void Shoot()
    {        
        if (ShootJoystick.Vertical > 0.2f || ShootJoystick.Vertical < -0.2f || ShootJoystick.Horizontal > 0.2f || ShootJoystick.Horizontal < -0.2f)
        {
            if (ShootTime <= 0)
            {
                Vector3 direction = Vector3.up * ShootJoystick.Vertical + Vector3.right * ShootJoystick.Horizontal;
                Bullet b = Instantiate(Bullet);
                b.MoveAway(transform.position, direction);
                SkeletonAnimation.AnimationState.SetAnimation(3, ELF_HIT, false);
                ShootTime = ShootCooldown;
            }            
        }
    }

    private void Move()
    {
        Vector3 direction = Vector3.up * MoveJoystick.Vertical + Vector3.right * MoveJoystick.Horizontal;
        Rigidbody2D.AddForce(direction * MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
    }
}
