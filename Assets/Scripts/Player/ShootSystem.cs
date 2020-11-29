using UnityEngine;
using System.Collections;
using System;

public class ShootSystem : MonoBehaviour
{
    private VariableJoystick ShootingJoystick;
    private GameObject Owner;

    [SerializeField] private Bullet Bullet;
    private float ShootCooldown = 1;
    private float ShootTime = 0;

    public delegate void PlayerShotedDel(GameObject owner);
    public static event PlayerShotedDel PlayerShotedEve;

    private void FixedUpdate()
    {   
        ShootTimer();
        Shoot();
    }
   
    public void Init(GameObject owner, VariableJoystick variableJoystick)
    {
        Owner = owner;
        ShootingJoystick = variableJoystick;
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
                PlayerModel playerModel = Owner.GetComponent<PlayerModel>();
                b.MoveAway(playerModel.GetPlayerView().transform.position, direction);
                PlayerShotedEve?.Invoke(Owner);
                ShootTime = ShootCooldown;
            }
        }
    }
}
