using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelTrigger : MonoBehaviour
{
    public delegate void StartLevelTriggerVisibleDel();
    public static event StartLevelTriggerVisibleDel StartLevelTriggerVisibleEve;

    private void OnBecameVisible()
    {
        Debug.Log("StartLevelTriggerVisible");
        StartLevelTriggerVisibleEve?.Invoke();
    }    
}
