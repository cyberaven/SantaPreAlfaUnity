using System.Collections;
using UnityEngine;


public class Bomb : MonoBehaviour
{
    [SerializeField] private MovingSystem MovingSystem;
    private Rigidbody2D Rigidbody2D;
    private float MoveSpeed = 100f;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);
    }

    public void MoveAway(Vector3 startPosition, Vector3 direction)
    {
        transform.position = startPosition;
        MovingSystem.Init(Rigidbody2D, direction, MoveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "House")
        {
            Die();
        }
    }   

    private void Die()
    {
        Destroy(gameObject);
    }

    public MovingSystem GetMovingSystem()
    {
        return MovingSystem;
    }

}
