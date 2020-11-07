using UnityEngine;
using System.Collections;
using System;

public class PlayerMoveSystem : MonoBehaviour
{
    private Player Player;
    private Rigidbody2D Rigidbody2D;
    private UserControll UserControll;

    [SerializeField] private float MoveUpSpeed = 10f;
    [SerializeField] private ForceMode2D ForceMode2D = ForceMode2D.Force;
    [SerializeField] private bool RotateToCourseEnable = true;    

    public void GiveMeRb2D(Player player)
    {
        Player = player;
        if (!Player)
        {
            throw new System.Exception("Player NULL go: " + gameObject);
        }
        
        Rigidbody2D = Player.GetRb2D();
        if (!Rigidbody2D)
        {
            throw new System.Exception("Rigidbody2D NULL go: " + gameObject);
        }

        UserControll = player.GetUserControll();        
        if(!UserControll)
        {
            throw new System.Exception("UserControll NULL go: " + gameObject);
        }

        UserControll.UserOutEve += Move;

    }
    private void Update()
    {
        RotateToCourse();        
        Debug.Log("Speed: " + Rigidbody2D.velocity.magnitude);
    }

    private void RotateToCourse()
    {
        if(RotateToCourseEnable)
        {            
            Player.transform.up = Rigidbody2D.velocity.normalized;
        }        
    }

    private void Move(EUserOutSignal signal)
    {
        if (signal == EUserOutSignal.PressUp)
        {
            Debug.Log("Fly up.");
            Rigidbody2D.AddForce(Player.gameObject.transform.up * MoveUpSpeed, ForceMode2D);
        }
        if (signal == EUserOutSignal.PressDown)
        {
            Debug.Log("Fly down.");
            //-1 переворачивает вектор вверх ногами.
            Rigidbody2D.AddForce(Player.gameObject.transform.up * -1 * MoveUpSpeed, ForceMode2D);
        }
        if (signal == EUserOutSignal.PressRight)
        {
            Debug.Log("Fly right.");
            Rigidbody2D.AddForce(Player.gameObject.transform.right * MoveUpSpeed, ForceMode2D);
        }
        if (signal == EUserOutSignal.PressLeft)
        {
            Debug.Log("Fly left.");
            //-1 переворачивает вектор вверх ногами.
            Rigidbody2D.AddForce(Player.gameObject.transform.right * -1 * MoveUpSpeed, ForceMode2D);
        }  
    }
}
