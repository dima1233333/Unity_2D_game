using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite _activeLever;

    private SpriteRenderer _spriteRenderer;

    private Sprite _Lever;
    private bool _activated;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _Lever = _spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();
        if(player != null && !_activated)
        {
            _spriteRenderer.sprite = _activeLever;
            _activated = true;
            Debug.Log("Active ");
        }
        
    }
}
