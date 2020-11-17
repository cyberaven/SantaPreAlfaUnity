using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour, IPlayer
{
    private VariableJoystick MoveJoystick;
    private VariableJoystick ShootJoystick;

    [SerializeField] private ShootSystem ShootSystem;
    [SerializeField] private MovingSystem MovingSystem;
    
    private Rigidbody2D Rigidbody2D;    

    private void Awake()
    {        
        Rigidbody2D = GetComponent<Rigidbody2D>();

        MovingSystem = Instantiate(MovingSystem, transform);        
        ShootSystem = Instantiate(ShootSystem, transform);        
    }
   
    public void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick)
    {
        MoveJoystick = moveJoystick;
        MovingSystem.SetPlayer(this);

        ShootJoystick = shootJoystick;
        ShootSystem.SetPlayer(this);
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
