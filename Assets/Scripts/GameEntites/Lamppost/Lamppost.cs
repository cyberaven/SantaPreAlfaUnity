using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamppost : MonoBehaviour
{
    private int Health = 2;

    public delegate void LamppostCreatedDel(Lamppost lamppost);
    public static event LamppostCreatedDel LamppostCreatedEve;

    public delegate void LamppostHitDel(Lamppost lamppost);
    public static event LamppostHitDel LamppostHitEve;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {            
            TakeDamage();            
        }
    }

    private void TakeDamage()
    {
        if(Health < 0)
        {
            Health = 0;
        }

        if (Health == 0)
        {
            LamppostHitEve?.Invoke(this);
        }
        else
        {
            Health--;
            LamppostHitEve?.Invoke(this);
        }
    }

    public int GetHealth()
    {
        return Health;
    }
}
