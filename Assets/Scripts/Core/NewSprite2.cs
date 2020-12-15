using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SignalBus0000001
{
    public class NewSprite : MonoBehaviour
    {
        private void Start()
        {            
            Signal signal = new Signal(1, "frstSignall");            
        }
    }
}
