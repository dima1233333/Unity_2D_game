using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Lever1 : MonoBehaviour
{
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Chest1 _chest;

    private SpriteRenderer _spriteRenderer;

    private Sprite _inactiveSprite;

    private bool _activated;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inactiveSprite = _spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl player = collision.GetComponent<PlayerControl>();
        if (player != null && !_activated)
        {
            _spriteRenderer.sprite = _activeSprite;
            _activated = true;
            _chest.Activated = true;
            Debug.Log("Activated!");
        }
    }

}