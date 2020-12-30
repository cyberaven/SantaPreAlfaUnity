using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField] public float BulletVsHome = 1;
    [SerializeField] public float BulletVsLampPost = 2;
    [SerializeField] public float BulletVsVirus = 5;

    public delegate void BulletTouchHouseDel(float point);
    public static event BulletTouchHouseDel BulletTouchHouseEve;

    public delegate void BulletTouchLampPostDel(float point);
    public static event BulletTouchLampPostDel BulletTouchLampPostEve;

    public delegate void BulletTouchVirusDel(float point);
    public static event BulletTouchVirusDel BulletTouchVirusEve;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "House")
        {
            BulletTouchHouseEve?.Invoke(BulletVsHome);
            Die();
        }
        if(collision.tag == "Lamppost")
        {
            BulletTouchLampPostEve?.Invoke(BulletVsLampPost);
            LampCollision(collision);
        }
        if (collision.tag == "Virus")
        {
            BulletTouchVirusEve?.Invoke(BulletVsVirus);
            Die();
        }
    }

    private void LampCollision(Collider2D collision)
    {
        Lamppost l = collision.gameObject.GetComponent<Lamppost>();        

        if (l.GetCurrentHealth() > 0)
        {
            Die();
        }
    }
   
}
