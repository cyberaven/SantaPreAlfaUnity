using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SignalBus0000001
{
    public class NewSprite1 : MonoBehaviour, ISignalListener
    {
        private void Start()
        {
            Listener listener = new Listener(this);
        }

        private void ChangeSpriteColor()
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }
}
