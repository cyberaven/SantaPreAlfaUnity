using UnityEngine;
using System.Collections;


public class FollowToObjSystem : MonoBehaviour
{
    private Transform Obj;
    private bool FollowPlayerOn = false;

    private void Update()
    {
        FollowPlayer();
    }
    public void FollowOn(Transform obj)
    {
        if(!obj)
        {
            throw new System.Exception("FollowToObjSystem Obj is NULL.");
        }

        Obj = obj;
        FollowPlayerOn = true;
    }
    private void FollowPlayer()
    {
        if (FollowPlayerOn)
        {
            transform.position = new Vector3(Obj.transform.position.x, 0, Obj.transform.position.z);
        }
    }
}
