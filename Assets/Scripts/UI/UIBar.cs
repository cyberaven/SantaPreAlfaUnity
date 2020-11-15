using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    private int MinValue = 0;
    private int MaxValue = 187;

    private RectTransform RectTransform;

    [SerializeField] private Image FillImage;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }    
}
