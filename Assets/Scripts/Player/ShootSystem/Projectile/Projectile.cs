using System;
using System.Collections;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private MovingSystem MovingSystem;
    [SerializeField] private float Cooldown = 1f;
    [SerializeField] private float LiveTime = 5f;

    private Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);
    }
    private void Update()
    {
        CheckLiveTime();
    }

    private void CheckLiveTime()
    {
        LiveTime--;
        if (LiveTime < 0) Die();
    }

    public void MoveAway(Vector3 startPosition, Vector3 direction)
    {
        transform.position = startPosition;
        MovingSystem.DirectionMoveOn(Rigidbody2D, direction);
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
