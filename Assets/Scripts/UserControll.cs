using UnityEngine;

public class UserControll : MonoBehaviour
{
    public delegate void UserOutDel(EUserOutSignal signal);
    public static UserOutDel UserOutEve;
        
    private void Update()
    {        
        if(Input.GetKey("up"))
        {
            Debug.Log("User press up.");
            UserOutEve?.Invoke(EUserOutSignal.PressUp);

        }
        if (Input.GetKey("down"))
        {
            Debug.Log("User press up.");
            UserOutEve?.Invoke(EUserOutSignal.PressDown);
        }
        if (Input.GetKey("left"))
        {
            Debug.Log("User press left.");
            UserOutEve?.Invoke(EUserOutSignal.PressLeft);

        }
        if (Input.GetKey("right"))
        {
            Debug.Log("User press uright.");
            UserOutEve?.Invoke(EUserOutSignal.PressRight);
        }
    }
}