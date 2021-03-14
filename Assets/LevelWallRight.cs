using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWallRight : MonoBehaviour
{
    public delegate void LevelWallRightTouchLocationEndTrigerDel();
    public static event LevelWallRightTouchLocationEndTrigerDel LevelWallRightTouchLocationEndTrigerEve;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LocationEndTriger")
        {
            Debug.Log("LevelWallRightTouchLocationEndTrigerEve");
            LevelWallRightTouchLocationEndTrigerEve?.Invoke();
        }
    }   
}
