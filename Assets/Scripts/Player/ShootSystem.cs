using UnityEngine;
using System.Collections;
using System;

public class ShootSystem : MonoBehaviour
{
    private VariableJoystick ShootingJoystick;

    [SerializeField] private Bullet Bullet;
    private float ShootCooldown = 1;
    private float ShootTime = 0;

    private IPlayer Player;

    public delegate void PlayerShotedDel(IPlayer player);
    public static event PlayerShotedDel PlayerShotedEve;

    private void FixedUpdate()
    {   
        ShootTimer();
        Shoot();
    }
   
    public void SetPlayer(IPlayer player)
    {
        Player = player;
        ShootingJoystick = player.GetShootingJoystick();
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
        if (ShootingJoystick.Vertical > 0.2f || ShootingJoystick.Vertical < -0.2f || ShootingJoystick.Horizontal > 0.2f || ShootingJoystick.Horizontal < -0.2f)
        {
            Vector3 direction = Vector3.up * ShootingJoystick.Vertical + Vector3.right * ShootingJoystick.Horizontal;

            if (ShootTime <= 0)
            {
                Bullet b = Instantiate(Bullet);
                b.MoveAway(transform.position, direction);
                PlayerShotedEve?.Invoke(Player);
                ShootTime = ShootCooldown;
            }
        }
    }
}
