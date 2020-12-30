using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamppost : MonoBehaviour, IHaveHealth
{
    [SerializeField] private int startHealth = 2;
    [SerializeField] private int maxHealth = 0;
    [SerializeField] private int minHealth = 0;

    private HealthSystem healthSystem;        

    public delegate void LamppostCreatedDel(Lamppost lamppost);
    public static event LamppostCreatedDel LamppostCreatedEve;

    private void Awake()
    {
        healthSystem = new HealthSystem(this, startHealth, maxHealth, minHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            ChangeHealth(-1);//Bullet.Damage = 1;
        }
    }

    public void Die()
    {       
    }
    public void ChangeHealth(int value)
    {
        healthSystem.ChangeHealth(value);
    }        
    public int GetCurrentHealth()
    {
        return healthSystem.GetHealth();
    }   
    public GameObject GetGameObject()
    {
        return gameObject;
    }
}

