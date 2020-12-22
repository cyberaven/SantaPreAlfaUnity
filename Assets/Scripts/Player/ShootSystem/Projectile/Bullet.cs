using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "House")
        {
            Die();
        }
        if(collision.tag == "Lamppost")
        {
            LampCollision(collision);
        }
        if (collision.tag == "Virus")
        {
            Die();
        }
    }

    private void LampCollision(Collider2D collision)
    {
        Lamppost l = collision.gameObject.GetComponent<Lamppost>();
        int lampHealth = l.GetHealth();

        if (lampHealth > 0)
        {
            Die();
        }
    }
   
}
