using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedText : MonoBehaviour
{
    private Text Text;

    private void Awake()
    {
        Text = GetComponent<Text>();
    }

    private void Update()
    {
        Text.text = "Speed: " + Player.Singelton.GetSpeed();
    }
}
