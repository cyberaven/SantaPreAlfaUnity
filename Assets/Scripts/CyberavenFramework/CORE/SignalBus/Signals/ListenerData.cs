using UnityEngine;
using System.Collections;

public class ListenerData
{
    IListen listener;
    public IListen Listener { get => listener;}
    

    Signal signal;
    public Signal Signal { get => signal;}
    
    bool onceTime = true;
    public bool OnceTime { get => onceTime; set => onceTime = value; }


    public ListenerData(IListen listener, Signal signal, bool onceTime)
    {               
        this.listener = listener;
        this.signal = signal;
        this.onceTime = onceTime;
        CheckListenerData();
    }

    void CheckListenerData()
    {
        if(listener == null || signal == null)
        {
            Debug.Log("Bad Listener Data. ");
        }
    }    
}
