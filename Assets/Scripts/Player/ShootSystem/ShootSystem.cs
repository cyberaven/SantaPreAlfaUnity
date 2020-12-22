using UnityEngine;
using System.Collections;
using System;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] private Bullet Bullet;
    private float ShootBulletCooldown = 1;
    private float ShootBulletTime = 0;
    private ProjectileCanon BulletProjectileCanon;

    [SerializeField] private Bomb Bomb;
    private float ShootBombCooldown = 1;
    private float ShootBombTime = 0;
    private ProjectileCanon BombProjectileCanon;

    private void Awake()
    {
        BulletProjectileCanon = new ProjectileCanon(Bullet, Bullet.GetCooldown());
        BombProjectileCanon = new ProjectileCanon(Bomb, Bomb.GetCooldown());
    }

    private void Update()
    {   
        ShootTimer();      //таймер надо инкапсулировать и унифицировать  
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
    public void Fire(EProjectileType projectileType, GameObject owner, Vector3 direction, Vector3 startPosition)
    {
        if(projectileType == EProjectileType.Bullet)
        {
            BulletProjectileCanon.Fire(owner,startPosition, direction);           
        }
        if (projectileType == EProjectileType.Bomb)
        {
            BombProjectileCanon.Fire(owner, startPosition, direction);
        }       
    }   
}

public class ProjectileCanon
{
    private Projectile Projectile;    
    private float Cooldown = 1;
    private float Time = 0;

    public delegate void PlayerShotedDel(GameObject owner);
    public static event PlayerShotedDel PlayerShotedEve;

    public ProjectileCanon(Projectile projectile, float coolDown)
    {
        Projectile = projectile;       
        Cooldown = coolDown;
    }

    public void Fire(GameObject owner, Vector3 direction, Vector3 startPosition)
    {
        Projectile p = UnityEngine.Object.Instantiate(Projectile);
        p.MoveAway(startPosition, direction);
        PlayerShotedEve?.Invoke(owner);        
    }    
}

