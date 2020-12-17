using UnityEngine;
using System.Collections;
using System;

public class FollowToObjSystem : MonoBehaviour
{  
    private bool FollowEnable = false;
    private Transform Followed;

    private bool ChangeX = false;
    private bool ChangeY = false;
    private bool ChangeZ = false;

    private void Update()
    {
        Follow();
    }

    public void FollowOn(Transform followed, bool changeX = true, bool changeY = true, bool changeZ = false)
    {
        if (!followed)
        {
            throw new System.Exception("FollowToObjSystem followed is NULL.");
        }

        Followed = followed;
        ChangeX = changeX;
        ChangeY = changeY;
        ChangeZ = changeZ;
        FollowEnable = true;
    }
    public void FollowOff()
    {
        FollowEnable = false;
    }
    
    private void Follow()
    {
        if (FollowEnable)
        {
            Vector3 fPos = Followed.position;
            Vector3 newPos = Vector3.zero;

            if (ChangeX)
            {
                newPos = new Vector3(fPos.x, transform.position.y, transform.position.z);
            }
            if (ChangeY)
            {
                newPos = new Vector3(transform.position.x, fPos.y, transform.position.z);
            }
            if (ChangeZ)
            {
                newPos = new Vector3(transform.position.x, transform.position.y, fPos.z);
            }

            transform.position = newPos;            
        }
    }   
}
