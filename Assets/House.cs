using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;

    [SerializeField] private List<Sprite> Sprites = new List<Sprite>();
    private int CurrentSprite = 0;
        
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Sprites[CurrentSprite];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            SetNextSprite();
        }
    }

    private void SetNextSprite()
    {
        CurrentSprite++;
        if (CurrentSprite <= Sprites.Count - 1)
        {
            SpriteRenderer.sprite = Sprites[CurrentSprite];
        }
    }
}
