using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour, IPlayer
{
    private VariableJoystick MoveJoystick;
    private VariableJoystick ShootJoystick;

    [SerializeField] private ShootSystem ShootSystem;
    [SerializeField] private MovingSystem MovingSystem;
    
    private Rigidbody2D Rigidbody2D;

    public delegate void PlayerCreatedDel(Player player);
    public static event PlayerCreatedDel PlayerCreatedEve;

    private void Awake()
    {
        PlayerCreatedEve?.Invoke(this);
        Rigidbody2D = GetComponent<Rigidbody2D>();

        MovingSystem = Instantiate(MovingSystem, transform);
        MovingSystem.SetPlayer(this);

        ShootSystem = Instantiate(ShootSystem, transform);
        ShootSystem.SetPlayer(this);
    }    
    private void OnEnable()
    {
        Camera.main.transform.SetParent(transform);
    }
    
    public void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick)
    {
        MoveJoystick = moveJoystick;
        ShootJoystick = shootJoystick;
    }
    
    public Rigidbody2D GetRigidbody2D()
    {
       return Rigidbody2D;
    }
    public VariableJoystick GetShootingJoystick()
    {
        return ShootJoystick;
    }
    public VariableJoystick GetMovingJoystick()
    {
        return MoveJoystick;
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
