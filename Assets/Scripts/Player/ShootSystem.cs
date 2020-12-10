using UnityEngine;
using System.Collections;
using System;

public enum EProjectileType
{ 
    Bullet,
    Bomb
}


public class ShootSystem : MonoBehaviour
{
    private VariableJoystick ShootingJoystick;
    private GameObject Owner;

    [SerializeField] private Bullet Bullet;
    private float ShootBulletCooldown = 1;
    private float ShootBulletTime = 0;

    [SerializeField] private Bomb Bomb;
    private float ShootBombCooldown = 1;
    private float ShootBombTime = 0;

    public delegate void PlayerShotedDel(GameObject owner);
    public static event PlayerShotedDel PlayerShotedEve;

    private void Update()
    {   
        ShootTimer();        
    }
   
    public void Init(GameObject owner, VariableJoystick variableJoystick)
    {
        Owner = owner;
        ShootingJoystick = variableJoystick;
    }

    private void ShootTimer()
    {
        if (ShootBulletTime > 0)
        {
            ShootBulletTime -= Time.deltaTime;
        }
        if (ShootBombTime > 0)
        {
            ShootBombTime -= Time.deltaTime;
        }
    }
    public void Shoot(EProjectileType projectileType, Vector3 direction)
    {
        if(projectileType == EProjectileType.Bullet)
        {
            ShootBullet(direction);
        }
        if (projectileType == EProjectileType.Bomb)
        {
            ShootBomb(direction);
        }

    }
    private void ShootBullet(Vector3 direction)
    {        
        if (ShootBulletTime <= 0)
        {
            Bullet b = Instantiate(Bullet);
            PlayerModel playerModel = Owner.GetComponent<PlayerModel>();
            b.MoveAway(playerModel.GetPlayerView().transform.position, direction);
            PlayerShotedEve?.Invoke(Owner);
            ShootBulletTime = ShootBulletCooldown;
        }        
    }
    private void ShootBomb(Vector3 direction)
    {   
        if(ShootBombTime <= 0)
        {
            Bomb b = Instantiate(Bomb);
            PlayerModel playerModel = Owner.GetComponent<PlayerModel>();
            b.MoveAway(playerModel.GetPlayerView().transform.position, direction);
            PlayerShotedEve?.Invoke(Owner);
            ShootBombTime = ShootBombCooldown;
        }
    }
}
