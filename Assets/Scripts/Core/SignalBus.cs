using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SignalBus0000001
{
    public class SignalBus : MonoBehaviour
    {
        //-//-//CORE zone
        private List<Signal> Signals = new List<Signal>();
        private List<Listener> Listeners = new List<Listener>();


        private void OnEnable()
        {
            Signal.CreateBornSignalEve += CreateBornSignalEve;
            Listener.CreateBornSignalListenerEve += CreateBornSignalListenerEve;
        }
        private void OnDisable()
        {
            Signal.CreateBornSignalEve -= CreateBornSignalEve;
            Listener.CreateBornSignalListenerEve -= CreateBornSignalListenerEve;
        }

        private void CreateBornSignalEve(Signal signal)
        {
            Signals.Add(signal);
        }
        private void CreateBornSignalListenerEve(ISignalListener signalListener)
        {
            Listeners.Add(signalListener as Listener);
        }
        //-//-//

        private void Start()
        {
            StartCoroutine(MessageSignalCount());
            StartCoroutine(MessageSignalListenerCount());
            StartCoroutine(CompareSignalsAndListeners());
        }
       
        IEnumerator MessageSignalCount()
        {
            while (true)
            {
                Debug.Log("Signals Count: " + Signals.Count);
                yield return new WaitForSecondsRealtime(5);                
            }
        }
        IEnumerator MessageSignalListenerCount()
        {
            while (true)
            {
                Debug.Log("Listeners Count: " + Listeners.Count);
                yield return new WaitForSecondsRealtime(5);
            }
        }
        IEnumerator CompareSignalsAndListeners()
        {
            while (true)
            {
                foreach (Listener listener in Listeners)
                {
                    foreach (Signal signal in Signals)
                    {
                        if(signal.Id == listener.Id)
                        {
                            listener.RunSystems(signal.Data);
                        }
                    }

                }
                yield return new WaitForSecondsRealtime(1);
            }
        }
    }
}
