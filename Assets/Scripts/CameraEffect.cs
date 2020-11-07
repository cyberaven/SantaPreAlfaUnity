using UnityEngine;
using System.Collections;


public class CameraEffect : MonoBehaviour
{
    private Camera MainCamera;
    
    private void Awake()
    {
        MainCamera = Camera.main;
    }
}