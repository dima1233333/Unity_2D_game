using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite _openSprite;

    private SpriteRenderer _spriteRenderer;

    private Sprite _chest;
    private bool _activated;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _chest = _spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();
        if (player != null && !_activated)
        {
            _spriteRenderer.sprite = _openSprite;
            _activated = true;
            Debug.Log("Avtived ");
        }
    }
}
