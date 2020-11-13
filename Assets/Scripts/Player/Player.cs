using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    private VariableJoystick MoveJoystick;
    private VariableJoystick ShootJoystick;

    [SerializeField] private ShootSystem ShootSystem;    

    private float MoveSpeed = 100f;
    private Rigidbody2D Rigidbody2D;

    public delegate void PlayerCreatedDel(Player player);
    public static event PlayerCreatedDel PlayerCreatedEve;

    public delegate void PlayerShotedDel(Player player, Vector3 direction);
    public static event PlayerShotedDel PlayerShotedEve;


    private void Awake()
    {
        PlayerCreatedEve?.Invoke(this);
        Rigidbody2D = GetComponent<Rigidbody2D>();

        ShootSystem = Instantiate(ShootSystem, transform);
        ShootSystem.SetPlayer(this);
    }

    
    private void OnEnable()
    {
        Camera.main.transform.SetParent(transform);
    }

    private void FixedUpdate()
    {
        Move();
        Shoot();
    }

    public void SetControllers(VariableJoystick moveJoystick, VariableJoystick shootJoystick)
    {
        MoveJoystick = moveJoystick;
        ShootJoystick = shootJoystick;

    }
    private void Move()
    {
        if (MoveJoystick.Vertical > 0.1f || MoveJoystick.Vertical < -0.1f || MoveJoystick.Horizontal > 0.1f || MoveJoystick.Horizontal < -0.1f)
        {
            Vector3 direction = Vector3.up * MoveJoystick.Vertical + Vector3.right * MoveJoystick.Horizontal;
            Rigidbody2D.AddForce(direction * MoveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
    private void Shoot()
    {
        if (ShootJoystick.Vertical > 0.2f || ShootJoystick.Vertical < -0.2f || ShootJoystick.Horizontal > 0.2f || ShootJoystick.Horizontal < -0.2f)
        {
            Vector3 direction = Vector3.up * ShootJoystick.Vertical + Vector3.right * ShootJoystick.Horizontal;            
            PlayerShotedEve?.Invoke(this, direction);
        }
    }
}
