using UnityEngine;
using System.Collections;


public class CyberavenUtilites : MonoBehaviour
{
    public static Vector2 RandomPosition(Vector2 worldCenter, int worldSize)
    {
        float x = Random.Range(worldCenter.x, worldSize);
        float y = Random.Range(worldCenter.y, worldSize);

        return new Vector2(x, y);
    }

    public static Vector3 RandomSize(Vector3 maxSize)
    {
        float r = Random.Range(0, maxSize.x);        
        return new Vector3(r,r,r);
    }

}
