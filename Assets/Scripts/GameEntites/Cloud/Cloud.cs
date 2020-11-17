using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class Cloud : MonoBehaviour
{
    public delegate void CloudCreatedDel(Cloud cloud);
    public static event CloudCreatedDel CloudCreatedEve;

    private void Awake()
    {
        CloudCreatedEve?.Invoke(this);
    }
}
