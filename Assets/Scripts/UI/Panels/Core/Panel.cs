using UnityEngine;
using System.Collections;


public class Panel : MonoBehaviour, IPanel
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
