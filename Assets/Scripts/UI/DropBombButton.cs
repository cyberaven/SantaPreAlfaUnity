using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropBombButton : MonoBehaviour, IPointerDownHandler
{
    public delegate void DropBombButtonClkDel();
    public static event DropBombButtonClkDel DropBombButtonClkEve;

    public void OnPointerDown(PointerEventData eventData)
    {
        DropBombButtonClkEve?.Invoke();
    }
}
