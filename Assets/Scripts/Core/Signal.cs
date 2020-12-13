using UnityEngine;
using System.Collections;
using System;

namespace SignalBus0000001
{
    public class Signal : MonoBehaviour
    {
        int id = 0;
        public int Id { get => id; set => id = value; }

        public string data = "";
        public string Data { get => data; set => data = value; }

        public delegate void SignalBornDel(Signal signal);
        public static event SignalBornDel CreateBornSignalEve;

        //Clutch - The Regulator Lyrics

        public Signal(int id, string data)
        {
            this.id = id;
            this.data = data;
                 
            DestroySelf();
            CreateBornSignal();            
        }
        private void CreateBornSignal()
        {
            CreateBornSignalEve?.Invoke(this);
        }
        private void DestroySelf()
        {
            if(id == 0)
            {
                Destroy(this);
            }
        }
    }
}