using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
}
