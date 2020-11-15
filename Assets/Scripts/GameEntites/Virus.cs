using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Virus : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer SpriteRenderer;

    //[SerializeField] private List<Sprite> Sprites = new List<Sprite>();
    private int CurrentSprite = 0;

    private float MoveAmplitude = 4f;
    private Vector3 TopMovePosition;
    private Vector3 BottomMovePosition; 
    private float MoveSpeed = 3f;

    //private void Awake()
    //{
    //    Rigidbody2D = GetComponent<Rigidbody2D>();
    //    SpriteRenderer = GetComponent<SpriteRenderer>();

    //    SpriteRenderer.sprite = Sprites[CurrentSprite];

    //    TopMovePosition = new Vector3(transform.position.x, transform.position.y + MoveAmplitude, transform.position.z);
    //    BottomMovePosition = new Vector3(transform.position.x, transform.position.y - MoveAmplitude, transform.position.z);
    //}
    //private void Start()
    //{
    //    Rigidbody2D.AddForce(Vector3.up * MoveSpeed, ForceMode2D.Impulse);
    //}
    private void Update()
    {
        Move();        
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Bullet")
    //    {           
    //        SetNextSprite();
    //    }
    //}

    private void Move()
    {
        if(transform.position.y > TopMovePosition.y)
        {          
            Rigidbody2D.AddForce(Vector3.down * MoveSpeed, ForceMode2D.Impulse);
        }
        if (transform.position.y < BottomMovePosition.y)
        {
            Rigidbody2D.AddForce(Vector3.up * MoveSpeed, ForceMode2D.Impulse);
        }
    }
    //private void SetNextSprite()
    //{
    //    CurrentSprite++;
    //    if (CurrentSprite <= Sprites.Count - 1)
    //    {
    //        SpriteRenderer.sprite = Sprites[CurrentSprite];
    //    }
    //}


    private SkeletonAnimation SkeletonAnimation;
    [SerializeField] private List<AnimationReferenceAsset> Animations = new List<AnimationReferenceAsset>();
    private int CurrentAnimation = 0;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //SpriteRenderer = GetComponent<SpriteRenderer>();

        //SpriteRenderer.sprite = Sprites[CurrentSprite];

        TopMovePosition = new Vector3(transform.position.x, transform.position.y + MoveAmplitude, transform.position.z);
        BottomMovePosition = new Vector3(transform.position.x, transform.position.y - MoveAmplitude, transform.position.z);

        SkeletonAnimation = GetComponent<SkeletonAnimation>();

    }
    private void Start()
    {
        Rigidbody2D.AddForce(Vector3.up * MoveSpeed, ForceMode2D.Impulse);

        SkeletonAnimation.AnimationState.SetAnimation(1, Animations[CurrentAnimation], true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            SetNextAnimation();
        }
    }

    private void SetNextAnimation()
    {
        CurrentAnimation++;
        if (CurrentAnimation <= Animations.Count - 1)
        {
            SkeletonAnimation.AnimationState.SetAnimation(1, Animations[CurrentAnimation], true);
        }
    }
}
