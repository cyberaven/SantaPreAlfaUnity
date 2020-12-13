using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteOnStart : MonoBehaviour
{
    [SerializeField] private List<Sprite> Sprites = new List<Sprite>();

    private SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SpriteRenderer.sprite = Sprites[Random.Range(0, Sprites.Count)];
    }
}
