using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class PlayerMoveSystem : MonoBehaviour
{
    private IMoveble IMoveble;
    private GameObject GameObject;
    private Rigidbody2D Rigidbody2D;    

    [SerializeField] private float MoveSpeed = 10f;
    [SerializeField] private ForceMode2D ForceMode2D = ForceMode2D.Force;
    [SerializeField] private bool RotateToCourseEnable = true;
        
    public void SetRb2D(IMoveble imoveble)
    {
        IMoveble = imoveble;

        GameObject = IMoveble.GetGameObject();
        if (!GameObject)
        {
            throw new System.Exception("GameObject NULL go: " + gameObject);
        }

        Rigidbody2D = IMoveble.GetRigidbody2D();
        if (!Rigidbody2D)
        {
            throw new System.Exception("Rigidbody2D NULL go: " + gameObject);
        }

        UserControll.UserOutEve += Move;
    }
    private void Update()
    {
        RotateToCourse();        
        //Debug.Log("Speed: " + Rigidbody2D.velocity.magnitude);
    }

    private void RotateToCourse()
    {
        if(RotateToCourseEnable)
        {
            IMoveble.GetGameObject().transform.up = Rigidbody2D.velocity.normalized;
        }        
    }

    private void Move(EUserOutSignal signal)
    {
        if (GameObject.tag == "Ship" && SceneManager.GetActiveScene().name != "PlanetMapScene")
        {
            if (signal == EUserOutSignal.KeyUp)
            {
                Debug.Log("Fly up.");
                Rigidbody2D.AddForce(GameObject.transform.up * MoveSpeed, ForceMode2D);
            }
            if (signal == EUserOutSignal.KeyDown)
            {
                Debug.Log("Fly down.");
                //-1 переворачивает вектор вверх ногами.
                Rigidbody2D.AddForce(GameObject.transform.up * -1 * MoveSpeed, ForceMode2D);
            }
            if (signal == EUserOutSignal.KeyRight)
            {
                Debug.Log("Fly right.");
                Rigidbody2D.AddForce(GameObject.transform.right * MoveSpeed, ForceMode2D);
            }
            if (signal == EUserOutSignal.KeyLeft)
            {
                Debug.Log("Fly left.");
                //-1 переворачивает вектор вверх ногами.
                Rigidbody2D.AddForce(GameObject.transform.right * -1 * MoveSpeed, ForceMode2D);
            }
        }
        if(GameObject.tag == "Cosmonavt")
        {
            if (signal == EUserOutSignal.KeyUp)
            {
                GameObject.transform.position = Vector3.MoveTowards(GameObject.transform.position, transform.up * 1000f, Time.deltaTime * MoveSpeed);
            }
            if (signal == EUserOutSignal.KeyDown)
            {
                GameObject.transform.position = Vector3.MoveTowards(GameObject.transform.position, -transform.up * 1000f, Time.deltaTime * MoveSpeed);
            }
            if (signal == EUserOutSignal.KeyRight)
            {
                GameObject.transform.position = Vector3.MoveTowards(GameObject.transform.position, transform.right * 1000f, Time.deltaTime * MoveSpeed);
            }
            if (signal == EUserOutSignal.KeyLeft)
            {
                GameObject.transform.position = Vector3.MoveTowards(GameObject.transform.position, -transform.right * 1000f, Time.deltaTime * MoveSpeed);
            }
        }
    }
}
