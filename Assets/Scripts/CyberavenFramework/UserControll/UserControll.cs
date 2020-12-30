using UnityEngine;

public class UserControll : MonoBehaviour
{
    public delegate void UserOutDel(EUserOutSignal signal);
    public static UserOutDel UserOutEve;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Update()
    {        
        if(Input.GetKey("up"))
        {
            Debug.Log("User press up.");
            UserOutEve?.Invoke(EUserOutSignal.KeyUp);
        }
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("User press up.");
            UserOutEve?.Invoke(EUserOutSignal.KeyDownUp);
        }

        if (Input.GetKey("down"))
        {
            Debug.Log("User press down.");
            UserOutEve?.Invoke(EUserOutSignal.KeyDown);
        }
        if (Input.GetKeyDown("down"))
        {
            Debug.Log("User press down.");
            UserOutEve?.Invoke(EUserOutSignal.KeyDownDown);
        }

        if (Input.GetKey("left"))
        {
            Debug.Log("User press left.");
            UserOutEve?.Invoke(EUserOutSignal.KeyLeft);

        }
        if (Input.GetKeyDown("left"))
        {
            Debug.Log("User press left.");
            UserOutEve?.Invoke(EUserOutSignal.KeyDownLeft);

        }

        if (Input.GetKey("right"))
        {
            Debug.Log("User press right.");
            UserOutEve?.Invoke(EUserOutSignal.KeyRight);
        }
        if (Input.GetKeyDown("right"))
        {
            Debug.Log("User press right.");
            UserOutEve?.Invoke(EUserOutSignal.KeyDownRight);
        }
        
        if (Input.GetKey("space"))
        {
            Debug.Log("User press space.");
            UserOutEve?.Invoke(EUserOutSignal.KeySpace);
        }
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("User press space.");
            UserOutEve?.Invoke(EUserOutSignal.KeyDownSpace);
        }
    }
}