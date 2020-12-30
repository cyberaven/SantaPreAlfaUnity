using UnityEngine;
using System.Collections;

public class Signal
{
    private int id = 0;
    public int Id { get => id;}
        
    private ESignalSelfName selfName;
    public ESignalSelfName SelfName { get => selfName;}
    
    private bool onceTime = true;
    public bool OnceTime { get => onceTime; set => onceTime = value; }
    
    public Signal(ESignalSelfName selfName, bool onceTime = true)
    {
        this.id = SignalBus.INSTANCE.GetNextSignalId();
        this.selfName = selfName;
        this.onceTime = onceTime;
        CheckSignalData();
    }

    private void CheckSignalData()
    {
        if(id == 0)
        {
            DestroySelf();
        }
        if(selfName == ESignalSelfName.SDestroySignalID2)
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Debug.Log("Signal DestroySelf. ID: " + this.id + " Name: " + this.SelfName);// TO DO : Доделать        
    }


}
