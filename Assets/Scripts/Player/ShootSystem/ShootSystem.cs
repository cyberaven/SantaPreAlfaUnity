using UnityEngine;
using System.Collections;
using System;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] private Bullet Bullet;   
    private ProjectileCanon BulletProjectileCanon;

    [SerializeField] private Bomb Bomb;    
    private ProjectileCanon BombProjectileCanon;

    private void Awake()
    {
        BulletProjectileCanon = new ProjectileCanon(Bullet, Bullet.GetCooldown());
        BombProjectileCanon = new ProjectileCanon(Bomb, Bomb.GetCooldown());
    }
    
    public void Fire(EProjectileType projectileType, GameObject owner, Vector3 direction, Vector3 startPosition)
    {
        if(projectileType == EProjectileType.Bullet)
        {
            BulletProjectileCanon.Fire(owner, direction, startPosition);           
        }
        if (projectileType == EProjectileType.Bomb)
        {
            BombProjectileCanon.Fire(owner, direction, startPosition);
        }       
    }   
}



