using System;
using System.Collections;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private MovingSystem MovingSystem;
    [SerializeField] private float Cooldown = 2000f;
    [SerializeField] private float LiveTime = 5000f;

    [SerializeField] private float MoveSpeed = 500f;
    [SerializeField] private float MinSpeed = 100f;
    [SerializeField] private float MaxSpeed = 700f;

    private CooldownTimer LiveTimeTimer;

    private Rigidbody2D Rigidbody2D;

    private void Awake()
    {        
        LiveTimeTimer = new CooldownTimer(LiveTime);
        LiveTimeTimer.Go();

        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);
    }
    private void Update()
    {        
       CheckLiveTime();
    }

    private void CheckLiveTime()
    {
        if (LiveTimeTimer.Check) Die();
    }

    public void MoveAway(Vector3 startPosition, Vector3 direction)
    {
        transform.position = startPosition;
        MovingSystem.DirectionMoveOn(Rigidbody2D, direction, MoveSpeed, MaxSpeed, MinSpeed);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public MovingSystem GetMovingSystem()
    {
        return MovingSystem;
    }
    public float GetCooldown()
    {
        return Cooldown;
    }
}
