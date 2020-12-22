using System.Collections;
using UnityEngine;


public class Bomb : Projectile
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "House")
        {
            Die();
        }
    }
}
