using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private void Awake()
    {
        Canvas c = GetComponent<Canvas>();
        c.worldCamera = Camera.main;
    }
}
