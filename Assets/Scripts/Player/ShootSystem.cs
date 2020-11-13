using UnityEngine;
using System.Collections;
using System;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] private Bullet Bullet;
    private float ShootCooldown = 1;
    private float ShootTime = 0;
    private Vector3 Direction;

    private Player Player;

    private void Awake()
    {
        Player.PlayerShotedEve += PlayerShoted;
    }
    private void FixedUpdate()
    {        
        ShootTimer();
    }

    private void PlayerShoted(Player player, Vector3 direction)
    {
        if(player == Player)
        {
            Direction = direction;
            Shoot();
        }
    } 
    public void SetPlayer(Player player)
    {
        Player = player;
    }
    private void ShootTimer()
    {
        if (ShootTime > 0)
        {
            ShootTime -= Time.deltaTime;
        }
    }

    private void Shoot()
    {        
        if (ShootTime <= 0)
        {                
            Bullet b = Instantiate(Bullet);
            b.MoveAway(transform.position, Direction);            
            ShootTime = ShootCooldown;
        }              
    }
}
