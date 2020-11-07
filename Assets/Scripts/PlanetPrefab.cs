using UnityEngine;
using System.Collections;

public class PlanetPrefab : MonoBehaviour
{
    [SerializeField] private Vector3 MaxSize = new Vector3(1000, 1000, 1000);

    public Vector3 GetMaxSize()
    {
        return MaxSize;
    }
}
