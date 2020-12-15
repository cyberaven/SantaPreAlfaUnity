using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{   
    [Header("Конфиг Модели")]
    [SerializeField] private float MaxMovingSpeed = 20f;
    [SerializeField] private float MinMovingSpeed = 10f;
    public string CurrentSpeed = "";
    [Space]
    [Header("Компоненты Модели")]
    [SerializeField] private MovingSystem MovingSystem;
    [SerializeField] private PlayerView PlayerView;
    [SerializeField] private Transform PlayerViewStartPosition;
    [SerializeField] private PlayerLogick PlayerLogick;
    [Space]
    private Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        MovingSystem = Instantiate(MovingSystem, transform);

        PlayerLogick.SetPlayerModel(this);
        SetViewOnStartPosition();
    }
    private void OnEnable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
    }
    private void OnDisable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
    }
    private void Update()
    {
        CurrentSpeed = MovingSystem.CurentSpeed;
    }

    public void ChangeMoveSpeed(float delta)
    {
        float currentSpeed = MovingSystem.TrDirectionMoveSpeed;
        float newSpeed = currentSpeed + delta;
        if (newSpeed < MaxMovingSpeed && newSpeed > MinMovingSpeed)
        {
            MovingSystem.Init(transform, new Vector3(999999, 0, 0), newSpeed);
        }
    }
    public void SetViewAsset(PlayerViewAsset playerViewAsset)
    {
        PlayerView.SetAnimationPack(playerViewAsset.GetAnimationPack());
    }
    public void SetControllers(VariableJoystick MoveJoystick, VariableJoystick ShootJoystick)
    {
        PlayerLogick.SetControllers(MoveJoystick, ShootJoystick);
    }
    public PlayerView GetPlayerView()
    {
        return PlayerView;
    }
    public PlayerLogick GetPlayerLogick()
    {
        return PlayerLogick;
    }
    public Transform GetViewStartPosition()
    {
        return PlayerViewStartPosition;
    }


    private void LevelCreated(Level level)
    {
        MovingSystem.Init(transform, new Vector3(999999f,0,0), 10f);
    }
    private void SetViewOnStartPosition()
    {
        PlayerView.transform.localPosition = PlayerViewStartPosition.position;
    }
}
