using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CyberavenUtilites : MonoBehaviour
{
    public static Vector2 RandomPosition2D(Vector2 worldCenter, int worldSize)
    {
        float x = Random.Range(worldCenter.x, worldSize);
        float y = Random.Range(worldCenter.y, worldSize);

        return new Vector2(x, y);
    }
    public static Vector3 RandomPosition3D(Vector3 worldCenter, int worldSize)
    {
        float x = Random.Range(worldCenter.x, worldSize);
        float y = Random.Range(worldCenter.y, worldSize);
        float z = Random.Range(worldCenter.z, worldSize);

        return new Vector3(x, y, z);
    }
    public static Vector3 RandomSize(Vector3 maxSize)
    {
        float r = Random.Range(0, maxSize.x);        
        return new Vector3(r,r,r);
    }
    public static string GetRandomString(List<string> strings)
    {
        string result = "";

        result = strings[Random.Range(0, strings.Count)];

        return result;

    }

    public static void SetParentMainCamera(Transform transform)
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0,0,-10f);
    }

}
