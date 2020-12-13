using UnityEngine;
using System.Collections;

namespace SignalBus0000001
{
    public class Listener
    {
        private ISignalListener SignalListener;

        int id = 0;
        public int Id { get => id; set => id = value; }

        public delegate void SignalListenerBornDel(ISignalListener signalListener);
        public static event SignalListenerBornDel CreateBornSignalListenerEve;

        public void RunSystems(string data)
        {
            //Listener<ISystem> Systems.All(data);
        }


        public Listener(ISignalListener signalListener)
        {
            SignalListener = signalListener;
            CreateBornSignalListenerEve?.Invoke(SignalListener);
        }
    }
}