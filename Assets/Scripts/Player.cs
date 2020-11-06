using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UserControll UserControll;
    [SerializeField] private PlayerMoveSystem PlayerMoveSystem;

    private Rigidbody2D Rigidbody2D;   


    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        UserControll = Instantiate(UserControll, transform);        

        PlayerMoveSystem = Instantiate(PlayerMoveSystem, transform);
        PlayerMoveSystem.GiveMeRb2D(this);
    }

    public Rigidbody2D GetRb2D()
    {
        return Rigidbody2D;
    }    
    public UserControll GetUserControll()
    {
        if (UserControll)
        {
            return UserControll;
        }
        else
        {
            throw new Exception("UserControll NULL go: " + gameObject);
        }
    }
}
