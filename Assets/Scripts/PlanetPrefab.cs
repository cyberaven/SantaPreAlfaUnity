using UnityEngine;
using System.Collections;

public class PlanetPrefab : MonoBehaviour
{
    [SerializeField] private Vector3 MaxSize = new Vector3(100, 100, 100);

    public Vector3 GetMaxSize()
    {
        return MaxSize;
    }
}
