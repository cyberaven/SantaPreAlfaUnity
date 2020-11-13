using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerDownHandler
{
    public delegate void StartButtonClkDel();
    public static event StartButtonClkDel StartButtonClkEve;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartButtonClkEve?.Invoke();
    }
}
